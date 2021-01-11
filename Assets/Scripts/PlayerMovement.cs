using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    public float jumpVelocity = 10f;
    private float x;
    private float z;
    public CharacterController cc;
    public Animator anim;

    public float mouseSensitivity = 500f;
    private float xRotation = 0f;
    public Transform cameraTransform;

    Vector3 velocity;
	// Update is called once per frame
	private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }

        if (cc.isGrounded) {
            velocity.y = 0;
            if (Input.GetKeyDown(KeyCode.Space)) {
                velocity.y = Mathf.Sqrt(jumpVelocity * -2f * Physics.gravity.y);
                anim.SetBool("jump", true);
            } else {
                anim.SetBool("jump", false);
            }
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        anim.SetFloat("x", x);
        anim.SetFloat("z", z);

        Vector3 move = transform.right * x + transform.forward * z;

        cc.Move(move * speed * Time.deltaTime);
        velocity.y += Physics.gravity.y * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);


        //camera controls
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation - mouseY, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
