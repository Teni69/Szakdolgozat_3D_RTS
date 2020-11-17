using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementManager : MonoBehaviour
{
    private Vector3 targetDestination;
    private Vector3 lookAtTarget;
    private float speed = 20f;
    private bool moving = false;

    void Update()
    {
        SetTargetDestination();
        Move();
    }

    void SetTargetDestination()
    {
        if(selectManager.isSelected == true){
        Ray ray = Camera.main.ViewportPointToRay(Camera.main.ScreenToViewportPoint(Input.mousePosition));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if(Input.GetMouseButtonDown(1))
                {
                    if(selection.CompareTag("planet1"))
                    {
                        targetDestination = hit.point;
                        moving = true;
                    }
                }
            }
        }
    }

    void Move()
    {
        if(moving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetDestination, speed * Time.deltaTime);
            if(transform.position == targetDestination)
            {
                moving = false;
            }
        }
    }
}
