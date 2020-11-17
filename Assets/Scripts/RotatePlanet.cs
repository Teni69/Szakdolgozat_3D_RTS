using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public GameObject planet;
    public GameObject rotateAround;
    void Update()
    {
        /*transform.Rotate(0,-1*Time.deltaTime,0);
        if(planet.CompareTag("planet1"))
        transform.RotateAround(rotateAround.transform.position, Vector3.down, Time.deltaTime/2);
        if(planet.CompareTag("planet2"))
        transform.RotateAround(rotateAround.transform.position, Vector3.down, Time.deltaTime);*/
    }
}
