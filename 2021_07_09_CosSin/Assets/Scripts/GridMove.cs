using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove : MonoBehaviour
{
    private void OnMouseDrag()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(Vector3.MoveTowards(transform.position, pos, 2.0f));
    }


    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
