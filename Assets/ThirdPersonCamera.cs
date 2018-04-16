using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    //resources:
    //https://www.youtube.com/watch?v=Ta7v27yySKs

    private const float Y_ANGLE_MIN = 0.0f; //minumum camera y angle
    private const float Y_ANGLE_MAX = 50.0f; //maximum camera y angle

    public Transform lookAt; //object that camera looks at
    public Transform camTransform; //transform of camera itself (contains position)

    public Camera cam;

    private float distance = 8.0f; //distance from player
    private float currentX = 0.0f;
    private float currentY = 0.5f;
    private float sensitivityX = 6.0f; //horizontal camera sensitivity
    private float sensitivityY = 3.0f; //vertical camera sensitivity

    void Start()
    {
        camTransform = transform;
        cam = Camera.main; //set first enabled camera as main camera
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
       // currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

       // currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX); //restrict camera y-rotation


    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY + 50, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;

        camTransform.LookAt(lookAt.position); //camera follows rotation
    }


}
