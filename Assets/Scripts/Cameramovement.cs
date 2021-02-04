using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cameramovement : MonoBehaviour
{
    public GameObject planet;
    private Vector3 distanceBetween;
    public Text DistanceText; 
    public Camera map, planetBlueCam, planetRedCam;

    void Start() {
        DistanceText.text = distanceBetween.magnitude.ToString();
        transform.position = planet.transform.position - new Vector3(0, 0, 120);
        //planetBlueCam.transform.LookAt (planet.transform.position);
        map.enabled = false;
    }

    void LateUpdate()
    {
        HandleZoom();
        HandleCameraMovement();
        HandleCamera();
        //Egyelőre mindkét kamera egyszerre mozog
    }

    void HandleCameraMovement(){
        /*if(Input.GetKey(KeyCode.A)) {   
            transform.RotateAround(planet.transform.position, Vector3.up, 90 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)) {   
            transform.RotateAround(planet.transform.position, Vector3.down, 90 * Time.deltaTime);
        }*/
        if(Input.GetKey(KeyCode.W)) {
            transform.RotateAround(planet.transform.position, transform.right, 90 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)) {   
            transform.RotateAround(planet.transform.position, -transform.right, 90 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Q)) {   
        transform.Rotate(0, 0, 90 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.E)) {   
        transform.Rotate(0, 0, -90 * Time.deltaTime);
        }    
    }

    void HandleZoom(){
        float zoomAmount = 50f; 
        distanceBetween = planet.transform.position - transform.position;
        DistanceText.text = distanceBetween.magnitude.ToString();
        if(Input.mouseScrollDelta.y > 0 && distanceBetween.magnitude >= 55f)
        {
            transform.position += transform.forward * zoomAmount * Time.deltaTime * 10f;
        }     
        if(Input.mouseScrollDelta.y < 0 && distanceBetween.magnitude <= 175f)
        {
            transform.position -= transform.forward * zoomAmount * Time.deltaTime * 10f;
        }
    }

    void HandleCamera(){
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(map.enabled == false)
            {
            map.enabled = true; planetBlueCam.enabled = false; planetRedCam.enabled = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
            {
               planetBlueCam.enabled = true; planetRedCam.enabled = false; map.enabled = false;
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                planetRedCam.enabled = true; planetBlueCam.enabled = false; map.enabled = false;
            }
    }
}
