using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float Sensitivity;

    private Transform cameraHead;

    private void Start()
    {
        cameraHead = transform.GetChild(0);
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        

        if(mouseX > 0)
        {
            //transform.rotation = Quaternion.LookRotation(new Vector3(0f, mouseX, 0f));
            transform.Rotate(0f, Sensitivity * Time.deltaTime, 0f);
        }
        if (mouseX < 0)
        {
            transform.Rotate(0f, -Sensitivity * Time.deltaTime, 0f);
        }

        if (mouseY < 0)
        {

            //transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.up, new Vector3(mouseY, 0, 0), Time.deltaTime * Sensitivity, 0));
            cameraHead.Rotate(Sensitivity * Time.deltaTime, 0f, 0f);
            
        }
        if (mouseY > 0)
        {
            cameraHead.Rotate(-Sensitivity * Time.deltaTime, 0f, 0f);
            
        }
        //if (cameraHead.rotation.x >= 90)
        //{
        //     cameraHead.transform.LookAt(new Vector3(90f, 0f, 0f));
        // }
        // if (cameraHead.rotation.x <= -90)
        // {
        //     cameraHead.transform.LookAt(new Vector3(-90f, 0f, 0f));
        // }

        //  if (Input.GetKey(KeyCode.W))
        //  {
        //     transform.Translate(0f, 0f, 1f);

        //  }

       // if (Input.GetKey(KeyCode.Q))
      //  {
      //     transform.Translate(0f, 0f, 1f);

            //  }

    }
}
