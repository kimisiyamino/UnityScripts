using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public GameObject point;
    public GameObject cameraPos;
    public float Speed;

    // Start is called before the first frame update
    private void OnMouseOver()
    {
        cameraPos.transform.RotateAround(point.transform.position, Vector3.up, Time.deltaTime * Speed);
        
    }

    private void OnMouseExit()
    {
        
    }
}
