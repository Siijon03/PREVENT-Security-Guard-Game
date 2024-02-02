using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Basic_Inputs : MonoBehaviour
{

    [SerializeField] private Camera _mainCamera;
 
    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Starting Screen");
            Debug.Log("Loading");
        }
    }

    //Setting our Camera to reference the unity camera.
    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    //Creating an OnClick Function for our Camera using unity input actions.
    public void OnClick(InputAction.CallbackContext Context)
    {
        if (!Context.started) return;

        //Creating a 'Ray' that will be fired from our mouses  current position and using the camera to help read the value.
        var RayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        //Return Click Collision on Hit
        if (!RayHit.collider) return;

        //Basic Debug Checking
        Debug.Log(RayHit.collider.gameObject.name);
    }
}
