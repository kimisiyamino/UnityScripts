using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCosSin : MonoBehaviour
{
    public Object EnemyPrefab;
    public float Distance = 2.0f;
    public float Angle = 360;
    public int Count = 10;
    public float _waitForSeconds = 3;

    // Start is called before the first frame update
    public IEnumerator tart()
    {
        Vector3 point = transform.position;
        
        // 360 deg = 6.28 rad = 2Pi
        Angle *= Mathf.Deg2Rad; // Mathf.Deg2Rad = Pi / 180 = 0.01744

        print("Angle in rad = " + Angle); // 6.28

        for (int i = 1; i <= Count; i++) {
            print("i = " + i);

            float cosX = Mathf.Cos(Angle / Count * i);
            float _x = transform.position.x + cosX * Distance;
            
            print("Cos = " + cosX);
            print("x = " + _x);

            // Angle / count * i = 6.28 / 10 * 1 = 0.28
            // cos(0.28) = 0.63

            // Angle / count * i = 6.28 / 10 * 2 = 0.28
            //
            //
            float sinY = Mathf.Sin(Angle / Count * i);
            float _y = transform.position.y + sinY * Distance;

            print("Sin = " + sinY);
            print("y = " + _y);


            point.x = _x;
            point.y = _y;

            Instantiate(EnemyPrefab, point, Quaternion.identity);
            yield return new WaitForSeconds(_waitForSeconds);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
