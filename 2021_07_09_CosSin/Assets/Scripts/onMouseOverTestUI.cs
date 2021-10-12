using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class onMouseOverTestUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Object EnemyPrefab;
    public Transform center;
    public float Distance = 2.0f;
    public float Angle = 360;
    public int Count = 10;
    public float _waitForSeconds = 3;

    private float _angle;

    public void OnPointerClick(PointerEventData eventData)
    {
        
        print("this");
        StartCoroutine(start());
        //throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = new Color(255.0f, 0.0f, 227.0f);
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f);
        //throw new System.NotImplementedException();
    }

    public IEnumerator start()
    {
        Vector3 point = center.position;
        _angle = Angle;
        // 360 deg = 6.28 rad = 2Pi
        _angle *= Mathf.Deg2Rad; // Mathf.Deg2Rad = Pi / 180 = 0.01744

        //print("Angle in rad = " + _angle); // 6.28

        for (int i = 1; i <= Count; i++)
        {
            //print("i = " + i);

            float cosX = Mathf.Cos(_angle / Count * i);
            float _x = center.position.x + cosX * Distance;

            //print("Cos = " + cosX);
            //print("x = " + _x);

            // Angle / count * i = 6.28 / 10 * 1 = 0.28
            // cos(0.28) = 0.63

            // Angle / count * i = 6.28 / 10 * 2 = 0.28
            //
            //
            float sinY = Mathf.Sin(_angle
                / Count * i);
            float _y = center.position.y + sinY * Distance;

            //print("Sin = " + sinY);
            //print("y = " + _y);


            point.x = _x;
            point.y = _y;

            Instantiate(EnemyPrefab, point, Quaternion.identity);
            yield return new WaitForSeconds(_waitForSeconds);
        }
    }
}
