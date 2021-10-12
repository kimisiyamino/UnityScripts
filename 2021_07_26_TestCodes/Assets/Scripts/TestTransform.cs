// code by EleonoraLion
//
// Input.GetAxis("Horizontal"); Vertical MouseX MouseY
// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTransform : MonoBehaviour
{

    public TextMesh textHorizontalVertical;
    public TextMesh textMouseXY;

    public float Speed;

    private Transform cube666;

    private float _Speed;
    void Start()
    {
        cube666 = GameObject.Find("Cube666").transform;
        Speed = 5f;
        _Speed = Speed;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        string horizontal = h.ToString("0.00000");
        string vertical = v.ToString("0.00000");
        //textMesh = GetComponent<TextMesh>();
        textHorizontalVertical.text = "Horizontal: " + horizontal + "\nVertical: " + vertical;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        string mousex = mouseX.ToString("0.00000");
        string mousey = mouseY.ToString("0.00000");

        textMouseXY.text = "Mouse X: " + mousex + "\nMouse Y: " + mousey;





        if (Input.GetButtonDown("Scale+")) {
            Vector3 currentScale = cube666.localScale; 
            cube666.localScale = new Vector3(currentScale.x + 1f, currentScale.y + 1f, currentScale.z + 1f);
        }
        if (Input.GetButtonDown("Scale-"))
        {
            Vector3 currentScale = cube666.localScale;
            cube666.localScale = new Vector3(currentScale.x - 1f, currentScale.y - 1f, currentScale.z - 1f);
        }

        if (h > 0)
        {
            cube666.Translate(Speed * Time.deltaTime, 0, 0);
        }
        else if (h < 0) {
            cube666.Translate(-Speed * Time.deltaTime, 0, 0);
        }
        if (v > 0)
        {
            cube666.Translate(0, 0, Speed * Time.deltaTime);
        }
        else if (v < 0)
        {
            cube666.Translate(0, -0, -Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q)) {
            cube666.Rotate(0f, -1f, 0f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            cube666.Rotate(0f, 1f, 0f);
        }

        if (Input.GetKey(KeyCode.F))
        {
            cube666.rotation = new Quaternion(0,0,0,0);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed *= 2f;
        }
        else {
            Speed = _Speed;
        }
    }
}
