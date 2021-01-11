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

    Vector3 velocity;
    // Update is called once per frame


    void Update()
    {
        if (cc.isGrounded) {
            velocity.y = 0;
            if (Input.GetKeyDown(KeyCode.Space)) {
                velocity.y = Mathf.Sqrt(jumpVelocity * -2f * Physics.gravity.y);
                anim.SetBool("jump", true);
            }
            else
                anim.SetBool("jump", false);
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        anim.SetFloat("x", x);
        anim.SetFloat("z", z);

        Vector3 move = transform.right * x + transform.forward * z;

        cc.Move(move * speed * Time.deltaTime);
        velocity.y += Physics.gravity.y * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }
}
