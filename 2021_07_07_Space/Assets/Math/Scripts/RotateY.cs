using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x, y, z);
    }
}
