// Code by Eleonora Lion
// https://docs.unity3d.com/ScriptReference/Transform.RotateAround.html
//
// Движение объекта вокруг target с поворотом своей оси

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Vector
{
    Left, Right, Up, Down
}

public class RotateAroundTarget : MonoBehaviour
{
    [Header("transform.RotateAround")]
    public bool isRotate = false;
    public GameObject target;
    public int degreesPerSecond = 20;
    public Vector axis = Vector.Up;

    private Vector3 _axis;

    void Update()
    {
        if (isRotate)
        {
            switch (axis)
            {
                case Vector.Left: _axis = Vector3.left; break;
                case Vector.Right: _axis = Vector3.right; break;
                case Vector.Down: _axis = Vector3.down; break;
                case Vector.Up: _axis = Vector3.up; break;
            }

            transform.RotateAround(target.transform.position, _axis, degreesPerSecond * Time.deltaTime);
        }
    }
}
