using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVxCAS : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 0.25f;

    Vector3 targetPosition;
    Vector3 StartPosition;

    bool moving;
    void Update()
    {
        if (moving)
        {
            if (Vector3.Distance(StartPosition, transform.position) > 1f)
            {
                transform.position = targetPosition;
                moving = false;
                return;
            }
            transform.position += (targetPosition - StartPosition) * moveSpeed * Time.deltaTime;
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            targetPosition = transform.position + Vector3.forward;
            StartPosition = transform.position;
            moving = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            targetPosition = transform.position + Vector3.back;
            StartPosition = transform.position;
            moving = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            targetPosition = transform.position + Vector3.left;
            StartPosition = transform.position;
            moving = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            targetPosition = transform.position + Vector3.right;
            StartPosition = transform.position;
            moving = true;
        }
    }
}
