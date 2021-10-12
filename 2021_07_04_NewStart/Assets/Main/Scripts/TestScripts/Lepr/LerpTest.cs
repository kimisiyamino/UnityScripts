using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public Transform redCubeTransform;
    public Transform greenCubeTransform;

    public float interpol = 0.0f;
    public float speed = 0.01f;


    [Header("ROTATE")]
    public bool isRotate = false;
    public float rotateX;
    public float rotateY;
    public float rotateZ;
   // public float rotationSpeed = 0.01f;

   // private bool rotate = false;

    void Start()
    {
        
    }

    void Update()
    {
        interpol += speed; 
        Vector3 newPosition = Vector3.Lerp(greenCubeTransform.position, redCubeTransform.position, interpol);

        transform.position = newPosition;

        if(isRotate)
            transform.Rotate(rotateX,rotateY,rotateZ);

        if (interpol >= 1) {
            interpol = 0;
        }
        
        
     }
}
