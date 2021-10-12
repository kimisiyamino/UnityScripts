// code by EleonoraLion
//
// ������������ (point1, point2) � Mathf.PingPong �� 0 �� Length �� ��������� Speed
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePingPong : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float Interpol, Speed, Length;

    void Update()
    {
        Interpol = Mathf.PingPong(Time.time * Speed, Length);
        transform.position = Vector3.Lerp(point1.position, point2.position, Interpol);
    }
}
