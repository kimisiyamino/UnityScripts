// https://www.loekvandenouweland.com/content/use-linerenderer-in-unity-to-draw-a-circle.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCircle : MonoBehaviour
{
    
    public int segments = 360;
    public float radius = 10.0f;

    public float x;
    public float y;

    public float _waitForSeconds = 3;

    public float lineWidth = .2f;
    public Material SphereMaterial;
    public Color color;


    public InputField InputX;
    public InputField InputY;
    public InputField InputRadius;

    public Transform point;
    public bool drawOnPoint;

    public void onClick()
    {
        if (drawOnPoint)
        {
            x = point.position.x;
            y = point.position.y;
            if (InputRadius.text != "")
            {
                radius = float.Parse(InputRadius.text);
            }
        }
        else
        {
            if (InputX.text != "")
            {
                x = float.Parse(InputX.text);
            }
            if (InputY.text != "")
            {
                y = float.Parse(InputY.text);
            }
            if (InputRadius.text != "")
            {
                radius = float.Parse(InputRadius.text);
            }
        }
        StartCoroutine(drawCircl());
    }

    IEnumerator drawCircl() {

        LineRenderer lineRenderer = new GameObject("Circle").AddComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.positionCount = segments + 1;
        lineRenderer.materials[0] = SphereMaterial;
        lineRenderer.material.color = Color.black;

        int pointCount = segments + 1; // add extra point to make startpoint and endpoint the same to close the circle
        Vector3[] points = new Vector3[pointCount];

        float rad = pointCount * Mathf.Deg2Rad;

        for (int i = 0; i <= pointCount; i++)
        {
            //float rad = Mathf.Deg2Rad * (i * 360f / segments);
            //points[i] = new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0);

            points[i] = new Vector3(Mathf.Cos(rad / pointCount * i) * radius + x, Mathf.Sin(rad / pointCount * i) * radius + y, 0);

            lineRenderer.SetPosition(i, points[i]);

            //lineRenderer.SetPositions(points);
            yield return new WaitForSeconds(_waitForSeconds);
        }
    }

}
