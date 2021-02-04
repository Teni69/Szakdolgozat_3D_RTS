using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementManager : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 targetDestination;
    private Vector3 direction;
    private float speed = 5f;
    private bool moving = false;

    void Start(){
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        SetTargetDestination();
    }

    void FixedUpdate() {
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
            direction = targetDestination - transform.position;
            direction = direction.normalized;
            rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
            if(transform.position == targetDestination)
            {
                moving = false;
            }
        }
    }
}
