using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteIcon : MonoBehaviour
{
    Color colorMain;
    private ResourceManager resourceManager;
    void Start()
    {
        colorMain = GetComponent<SpriteRenderer>().color;
        resourceManager = FindObjectOfType<ResourceManager>();
    }


    private void OnMouseUp()
    {
        if (Pause.isPause)
        {
            return;
        }

        resourceManager.Gold += resourceManager.getTower().Cost/2;
        Destroy(resourceManager.getTower().gameObject);
        resourceManager.TowerSell();

        Destroy(GameObject.FindGameObjectWithTag("BuildMenu"));
         
    }

    private void OnMouseOver()
    {
        if (Pause.isPause)
        {
            return;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
    }
    private void OnMouseExit()
    {
        if (Pause.isPause)
        {
            return;
        }

        // Делаем спрайт обычным
        GetComponent<SpriteRenderer>().color = colorMain;
    }
}
