using UnityEngine;
using UnityEngine.InputSystem;

public class LevelPlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public Rigidbody2D rigidBody;
    public Collider2D interactionCollider;
    public float speed;
    public float jumpPower;

    InputAction moveAction;
    InputAction interactAction;
    InputAction jumpAction;

    Vector2 direction;

    // Variable(s) for tracking collected items //
    private int itemCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the references to the "Move" and "Interact" actions
        moveAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Movement code
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        // moveValue = new Vector2(moveValue.x, 0);
        if (jumpAction.WasPressedThisFrame()){
            moveValue = new Vector2(moveValue.x, jumpPower);
            Debug.Log("jump pressed");
        }
        
        //Debug.Log(moveValue);
        rigidBody.linearVelocity = moveValue * speed /* * Time.deltaTime*/;
        // Debug.Log(rigidBody.linearVelocity);
    }

    public bool isInteractPressed()
    {
        //Debug.Log("Player Controller interactAction.IsPressed is " + interactAction.IsPressed());
        return interactAction.IsPressed();
    }

    // Code for collecting item //
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform")) // make sure platform tiles are set to "Platform" tag; check if player is touching the ground
        {
            // isGrounded = true;
        }
        else if (collision.CompareTag("Item") && collision.gameObject.activeSelf) // make sure all collectible items are set to "Item" tag
        {
            Material_Item material_Item = collision.GetComponent<Material_Item>();
            Inventory.inventory.Add_material(material_Item.Material_name,material_Item.quantity); // add the material to inventory
            collision.gameObject.SetActive(false);
            itemCounter += 1;
        }
    }

}
