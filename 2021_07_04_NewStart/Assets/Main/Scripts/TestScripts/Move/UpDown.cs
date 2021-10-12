using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float Speed, Angle, Radius;

    private float _y;

    void Start()
    {
        _y = transform.position.y;
    }


    void Update()
    {
        Angle += Time.deltaTime;

        float y = _y + Mathf.Cos(Speed * Angle) * Radius;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
