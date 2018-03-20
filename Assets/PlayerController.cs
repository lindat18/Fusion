using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //resources:
    //https://answers.unity.com/questions/196381/how-do-i-check-if-my-rigidbody-player-is-grounded.html
    //https://www.youtube.com/watch?v=NgV6iJC_F3s

    public float speed = 10;
    public float jumpVelocity = 10;
    public Vector3 startPos = new Vector3(0, 0, 0);
    private bool canJump = true;

    Rigidbody body;

    void Start()
    {
        if (GetComponent<Rigidbody>() != null) //init ridigbody
            body = GetComponent<Rigidbody>();
        else
            Debug.LogError("no rigidbody attached");

        enabled = false;

        transform.position = startPos;
    }

    // FixedUpdate is called once per physics-frame
    void FixedUpdate()
    {
        //Source: https://answers.unity.com/questions/1386777/get-origin-of-plane-in-world-coordinates.html
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mousePos = hit.point; //mouse position in world coordinates
            Vector3 playerPos = transform.position;
            float deltaX = mousePos.x - playerPos.x;
            float deltaZ = mousePos.z - playerPos.z;

            //Debug.Log(mousePos.x + " " + mousePos.z);

            Vector3 direction = new Vector3(deltaX, 0, deltaZ);

            transform.forward = direction;
            //transform.rotation = new Quaternion(0, 0, Mathf.Tan(deltaX / deltaZ), 0);
            //Debug.Log(transform.rotation);
        }

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
        return Physics.Raycast(transform.position, Vector3.down, transform.GetChild(0).GetComponent<Collider>().bounds.extents.y + 0.1f);
    }
}