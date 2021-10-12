using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triangleDeform : MonoBehaviour
{
    public Transform point;

    private float _x;

    void Update()
    {
        _x = point.position.x;

        LineRenderer triangle = GetComponent<LineRenderer>();
        triangle.SetPosition(1, point.position);
        triangle.SetPosition(2, new Vector3(_x, 0, 0));
    }
}
