using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public Rigidbody2D rigidBody;
    public Collider2D interactionCollider;
    public float speed;

    InputAction moveAction;
    InputAction interactAction;

    Vector2 direction;

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

    public bool isInteractPressed() {
        //Debug.Log("Player Controller interactAction.IsPressed is " + interactAction.IsPressed());
        return interactAction.IsPressed();
    }
    
}
