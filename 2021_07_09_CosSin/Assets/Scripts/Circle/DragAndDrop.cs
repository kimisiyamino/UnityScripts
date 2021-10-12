using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public Vector2 mousePos;

    public LineRenderer lineRenderer;

    public void OnMouseDown()
    {
        
    }

    public void OnMouseDrag()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        Vector3[] positions = new Vector3[lineRenderer.positionCount];
        for (int i = 0; i < positions.Length; i++) {
            positions[i] = lineRenderer.GetPosition(i);
        }


        //float rad = Mathf.Deg2Rad * (i * 360f / 360);
        //transform.Translate(new Vector2(Mathf.Sin(rad) * 10, Mathf.Cos(rad) * 10));

        transform.Translate(mousePos);
        //transform.position
    }
    void Update()
    {
        
    }
}
