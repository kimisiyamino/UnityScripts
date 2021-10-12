// code by EleonoraLion
//
// RotateTowards + LookRotation 
// ������� �� x, y, z ������� � ������� �������, �������� �� point

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
        // ����������� ������ �������� �����������
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, point.position - transform.position, Time.deltaTime * Speed, Magnitude);
        // ����-�������
        Debug.DrawRay(transform.position, newDirection * RayLength, color);
        // �������������� � ������������ � �������� (����� ��������� �������� ���)
        transform.rotation = Quaternion.LookRotation(new Vector3(newDirection.x, newDirection.y, newDirection.z));
    }
}
