using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings.SplashScreen;

public class character_movement : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 6f;
    [SerializeField] public float jumpSpeed = 5f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference jump;
    [SerializeField] InputActionReference sprint;

    Vector2 rawMove = Vector2.zero;

    float verticalVelocity = 0f;
    bool isGrounded = true;
    private void Update()
    {
        if (!isGrounded)
        {
            verticalVelocity = jumpSpeed += gravity * Time.deltaTime;
        }
        Vector3 moveToApply = new Vector3(rawMove.x, 0f, rawMove.y) * movementSpeed * Time.deltaTime;
        transform.Translate(moveToApply);
    }

    void OnMove(InputValue value)
    {
        rawMove = value.Get<Vector2>();
        //Debug.Log(rawMove);

    }
    void OnJump()
    {
        isGrounded = true;
        //Debug.Log("DoJUMP!");

    }
}