using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    CharacterController controller; 
    private float speed = 6;
    Camera cam;
    //serialize field makes the variable appear in inspector without //having to make it private
    [SerializeField] float rotationSmoothTime = -0.15f; 
    float currentAngle; 
    float currentAngleVelocity;
    float velocityY;

    [Header("Gravity")]
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float gravityMultiplier = 2;
    [SerializeField] float groundedGravity = -0.5f;
    [SerializeField] float jumpHeight = 3f;

void HandleGravityAndJump()
{
    if (controller.isGrounded && velocityY < 0f)
        velocityY = groundedGravity;
if (controller.isGrounded)
    {
        velocityY = Mathf.Sqrt(jumpHeight * 2f * gravity);
    }
velocityY -= gravity * gravityMultiplier * Time.deltaTime;
    controller.Move(Vector3.up * velocityY * Time.deltaTime);
}

// Start is called before the first frame update 
    void Awake() 
    {      
        controller = GetComponent<CharacterController>(); 
        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if (movement.magnitude >= 0.1f)
    {
        float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
        currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentAngleVelocity, rotationSmoothTime);
        transform.rotation = Quaternion.Euler(0, currentAngle-90, 0);
        controller.Move(movement* speed * Time.deltaTime);
    }
// "speed" is a private float variable that is used to control the speed of the player

    HandleGravityAndJump();

    }

    
}
