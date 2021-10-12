using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public Transform redCubeTransform;
    public Transform greenCubeTransform;

    public float interpol = 0.0f;
    public float speed = 0.001f;

    private bool rotate = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = Vector3.Lerp(greenCubeTransform.position, redCubeTransform.position, interpol);
        transform.position = newPosition;

        
        
     }
}
