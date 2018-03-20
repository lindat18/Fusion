using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //resources:
    //https://answers.unity.com/questions/196381/how-do-i-check-if-my-rigidbody-player-is-grounded.html
    //https://www.youtube.com/watch?v=NgV6iJC_F3s

    private float distToGround;

    public float speed;
    public float jumpVelocity;
    public Vector3 startPos;
    private bool canJump = true;


    Rigidbody body;

    private void Start()
    {
        distToGround = gameObject.GetComponent<Collider>().bounds.extents.y;

        if (GetComponent<Rigidbody>() != null) //init ridigbody
            body = GetComponent<Rigidbody>();
        else
            Debug.LogError("no rigidbody attached");

        transform.position = startPos;


        

    }

    // FixedUpdate is called once per physics-frame
    void FixedUpdate()
    {

        float yRotation = Camera.main.transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z); //make pplayer rotate with camera
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        body.velocity += transform.forward * Input.GetAxis("Vertical") * speed;
        body.velocity += transform.right * Input.GetAxis("Horizontal") * speed;


    }

    private void HandleJump()
    {

        canJump = false;

        if (IsGrounded())
        {
            canJump = true;
        }

        if (canJump == true)
        {
           

            if (Input.GetKey("space"))
            {
                body.velocity += new Vector3(0, jumpVelocity, 0);
                canJump = false;
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
    }


}