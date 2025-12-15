using UnityEngine;

public class character_movement : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 6f;
    [SerializeField] public float jumpForce = 5f;
    [SerializeField] private float gravity = -9.8f;
  
    private CharacterController player;
    private Vector3 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        player.Move(move * movementSpeed * Time.deltaTime);
      
        if (player.isGrounded && velocity.y < 0)
        { velocity.y = -2f; }

        if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded)
            { velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); }

        velocity.y += gravity * Time.deltaTime;
        player.Move(velocity * Time.deltaTime);
    }
}
