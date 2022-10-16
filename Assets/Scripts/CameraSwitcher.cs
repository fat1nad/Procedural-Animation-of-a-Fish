// Author: Fatima Nadeem / Croft (Please credit before direct usage)

using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] Transform cameraTarget; // Target followed by camera

    // "Cache" values
    Camera[] cameras; // All children and attached cameras
    int number; // Current active camera number/ number key pressed

    public static Camera CurrentCamera{get; private set;} // Current active camera

    void Start()
    {
        // Getting all children and attached cameras including inactive ones 
        cameras = GetComponentsInChildren<Camera>(true);

        if (cameras.Length > 0) // If there are any cameras
        {
            // Activating the very first camera
            CurrentCamera = cameras[0];
            CurrentCamera.enabled = true;

            // Deactivating the rest
            for (int i = 1; i < cameras.Length; i++)
            {
                cameras[i].enabled = false;
            }
        }        
    }

    void Update()
    {
        if (cameraTarget != null) // If there is a target to follow
        {
            transform.position = cameraTarget.position; 
            // Can be improved with dampening code
        }       
        
        if (int.TryParse(Input.inputString, out number) && (number > 0))
        // If a number key is pressed
        {
            // Converting to proper index
            number = (number - 1) % cameras.Length;

            // Setting selected camera as current active and disabling the rest
            for (int i = 0; i < cameras.Length; i++)
            {
                if (i == number)
                {
                    CurrentCamera = cameras[i];
                    CurrentCamera.enabled = true;                   
                }
                else
                {
                    cameras[i].enabled = false;
                }
            }
        }
    }
}
