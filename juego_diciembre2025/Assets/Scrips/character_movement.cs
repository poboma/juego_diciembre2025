using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings.SplashScreen;

public class character_movement : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 6f;
    [SerializeField] public float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -25f;
    CharacterController player;
  
    Vector2 rawMove = Vector2.zero;
    float verticalVelocity = 0f;
    
    private void Awake()
    {
        player = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 movement = new Vector3(rawMove.x, 0f, rawMove.y) * movementSpeed;
        

        if (player.isGrounded && verticalVelocity < 0)
        {
           verticalVelocity = -2f;
        }
        if (verticalVelocity < 0)
            verticalVelocity += gravity * Time.deltaTime; 
        else
            verticalVelocity += gravity * Time.deltaTime;

        verticalVelocity += gravity * Time.deltaTime;
        movement.y = verticalVelocity;

        player.Move(movement * Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        rawMove = value.Get<Vector2>();
      
    }
    void OnJump()
    {
        if (player.isGrounded) {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
            

        } }
}