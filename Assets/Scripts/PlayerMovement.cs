// Author: Fatima Nadeem / Croft (Please credit before direct usage)

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    //[SerializeField] float sinAngle = 30f; // Angle for sine wave animation

    // "Cache" values
    Camera currentCam; // Currently active camera

    Vector3 mousePos; // Mouse position
    Vector3 lookAtTarget; // Mouse position in world space
    
    Transform child; // Child armature for sine wave animation
    float childXAngle; // Interpolated value between -sinAngle and +sinAngle

    void Start()
    {
        child = transform.GetChild(0);
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // If left mouse button is held
        {
            currentCam = CameraSwitcher.CurrentCamera;

            // Converting mouse position from screen to world space point
            mousePos = Input.mousePosition;
            mousePos.z = currentCam.transform.localPosition.magnitude;
            lookAtTarget = currentCam.ScreenToWorldPoint(mousePos);

            // Setting rotation to look at mouse position
            transform.LookAt(lookAtTarget);
            // Setting position to move
            transform.position += moveSpeed * Time.deltaTime * transform.forward;

            // Setting child local x angle for sine wave animation
            //childXAngle = sinAngle * Mathf.Sin(2 * Mathf.PI * Time.time);
            //child.localRotation = Quaternion.AngleAxis(childXAngle, Vector3.up);
        }        
    }
}
