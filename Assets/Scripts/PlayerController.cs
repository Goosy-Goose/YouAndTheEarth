using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public float speed;

    Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        rigidBody.linearVelocity = direction * speed;
    }
}
