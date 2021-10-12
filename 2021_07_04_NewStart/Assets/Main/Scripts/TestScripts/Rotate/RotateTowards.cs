// code by EleonoraLion
//
// RotateTowards + LookRotation 
// Поворот по x, y, z объекта к другому объекту, слежение за point

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    public float Magnitude, Speed, RayLength;
    public Transform point;
    public Color color;

    void Update()
    {
        // Высчитываем вектор поворота направления
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, point.position - transform.position, Time.deltaTime * Speed, Magnitude);
        // Тест-рейкаст
        Debug.DrawRay(transform.position, newDirection * RayLength, color);
        // Поворачиваемся в соответствии с вектором (можем отключить ненужные оси)
        transform.rotation = Quaternion.LookRotation(new Vector3(newDirection.x, newDirection.y, newDirection.z));
    }
}
