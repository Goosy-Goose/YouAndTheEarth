using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelPlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public Rigidbody2D rigidBody;
    public Collider2D interactionCollider;
    public float speed;
    public float jumpPower = 4.0f;
    bool isJumping = false;
    bool isGrounded = false;

    InputAction moveAction;
    InputAction interactAction;
    InputAction jumpAction;

    Vector2 direction;

    private bool canGoHome;
    // Variable(s) for tracking collected items //
    private int itemCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the references to the "Move" and "Interact" actions
        moveAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
        jumpAction = InputSystem.actions.FindAction("Jump");
        canGoHome = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (interactAction.IsPressed() && canGoHome)
        {
            SceneManager.LoadScene(sceneName: "Store");
        }

    }

    void MovePlayer()
    {
        // Y VALUES DEPENDING ON JUMP
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        moveValue = moveValue * speed;
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            moveValue.y = jumpPower;
            isJumping = true;
        }
        else if (!isJumping && isGrounded) { moveValue.y = 0; }
        else { moveValue.y = rigidBody.linearVelocity.y; }

        // X MOMENTUM
        float airRes = 0.05f;
        if (isGrounded) { airRes = 0.1f; }
        if (rigidBody.linearVelocity.x > 0 && moveValue.x >= 0)
        {
            moveValue.x = Mathf.Max(moveValue.x, rigidBody.linearVelocity.x) - airRes;
        }
        else if (rigidBody.linearVelocity.x < 0 && moveValue.x <= 0)
        {
            moveValue.x = Mathf.Min(moveValue.x, rigidBody.linearVelocity.x) + airRes;
        }

        // SET VELOCITY
        rigidBody.linearVelocity = new Vector2(moveValue.x, moveValue.y);
    }

    public bool isInteractPressed()
    {
        return interactAction.IsPressed();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
    }

    // Code for collecting item //
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // isJumping = false;
        if (collision.CompareTag("Platform")) // make sure platform tiles are set to "Platform" tag; check if player is touching the ground
        {
            // this stuff for if collided on bottom
            isGrounded = true;
            isJumping = false;
        }
        else if (collision.CompareTag("Item") && collision.gameObject.activeSelf) // make sure all collectible items are set to "Item" tag
        {
            Material_Item material_Item = collision.GetComponent<Material_Item>();
            Inventory.inventory.Add_material(material_Item.materialName,material_Item.quantity); // add the material to inventory
            collision.gameObject.SetActive(false);
            itemCounter += 1;
        }
        else if (collision.CompareTag("Finish"))
        {
            canGoHome = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            isGrounded = false;
        }
        else if (collision.CompareTag("Finish"))
        {
            canGoHome = false;
        }
    }

}
