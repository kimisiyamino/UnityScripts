// code by EleonoraLion
//
// �������� ������� �� �������� ���� ����� ���� � ��������� �������, ��� ���� �����
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoints : MonoBehaviour
{
    
    public Point nextPoint;
    public float Speed;

    private Vector3 oldPoint;

    void Start()
    {
        // ������ ������
        oldPoint = new Vector3();
    }

    void Update()
    {
        // ��������� � ������ ����� nextPoint.transform.position ��������� Speed
        transform.position = Vector3.MoveTowards(transform.position, nextPoint.transform.position, Speed * Time.deltaTime);

        // ����� ����� ����������
        if (nextPoint.transform.position == transform.position) {
           
            Transform newPoint;
            do {
                // �������� � ����������� ����� �������� "������" (��������� �����)
                newPoint = nextPoint.NeighborPoints[(int)Random.Range(0f, 3f)];
            } while (oldPoint == newPoint.position); // ���� ��������� ����� = ���������� �����, �� ������ ����. (� ������ ������� ����� �� 3 �������)
                                                     // ��� ��� �� �� ����� ���������� �����

            // ��������� ����� ������� �����, ��� ����������
            oldPoint = nextPoint.transform.position;
            // ����� � nextPoint ������ "������"
            nextPoint = newPoint.GetComponent<Point>();
        }
    }
}
