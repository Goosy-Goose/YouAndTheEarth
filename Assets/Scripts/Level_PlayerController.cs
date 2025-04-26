using UnityEngine;
using UnityEngine.InputSystem;

public class LevelPlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public Rigidbody2D rigidBody;
    public Collider2D interactionCollider;
    public float speed;

    InputAction moveAction;
    InputAction interactAction;

    Vector2 direction;

    // Variable(s) for tracking collected items //
    private int itemCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the references to the "Move" and "Interact" actions
        moveAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
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
        //Debug.Log(moveValue);
        rigidBody.linearVelocity = moveValue * speed /* * Time.deltaTime*/;

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
            //isGrounded = true;
        }
        else if (collision.CompareTag("Item") && collision.gameObject.activeSelf) // make sure all collectible items are set to "Item" tag
        {
            collision.gameObject.SetActive(false);
            itemCounter += 1;
        }
    }

}
