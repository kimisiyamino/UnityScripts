using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    public Transform PlayerTransform;
    private Vector3 direction;

    [Range(0.0f, 1.0f)]
    public float SmoothFactor = 0.5f;
    
    void Start()
    {
        direction = transform.position - PlayerTransform.position;
        //print(_cameraOffset);
    }

    void LateUpdate()
    {
        Vector3 newPos = PlayerTransform.position + direction;

        print("CAMERA COORD: " + transform.position);
        print("NEW COORD: " + newPos);

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        print("NEW CAMERA COORD: " + transform.position);

    }
}
