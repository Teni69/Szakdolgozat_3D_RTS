using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetLight : MonoBehaviour
{
    public GameObject spotlight;
    public GameObject lightAround;
    void LateUpdate()
    {
        /*if(spotlight.CompareTag("p1light"))
        transform.RotateAround(lightAround.transform.position, Vector3.down, Time.deltaTime/2);
        if(spotlight.CompareTag("p2light"))
        transform.RotateAround(lightAround.transform.position, Vector3.down, Time.deltaTime);*/
    }
}
