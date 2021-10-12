using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuIcon : MonoBehaviour
{
    // Башня, которую будем строить
    public Tower tower;
    // ResourceManager
    private ResourceManager resourceManager;

    // Иконка-апгрейд, для того чтобы удалить старую башню
    public bool isUpgrade;

    // Хватает ли денег?
    private bool EnoughMoney;

    void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
    }

    private void OnMouseOver()
    {
        if (Pause.isPause)
        {
            return;
        }
        // Если хватает денег
        if (resourceManager.Gold >= tower.Cost)
        {
            // Делаем спрайт зелёным и даём знать, что при нажатии мыши мы построим башню (OnMouseUp())
            GetComponent<SpriteRenderer>().color = Color.green;
            EnoughMoney = true;
        }
        else // Если не хватает денег, делаем спрайт красным
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnMouseExit()
    {
        if (Pause.isPause)
        {
            return;
        }
        // Делаем спрайт обычным и даём знать что при нажатии мыши мы не построим башню
        GetComponent<SpriteRenderer>().color = Color.white;
        EnoughMoney = false;
    }


    private void OnMouseUp() 
    {
        if (Pause.isPause)
        {
            return;
        }
        // (Если хватает денег и мышь наведена на спрайт (Переменная EnoughMoney может стать true только в методе OnMouseOver()))
        if (EnoughMoney) {
            // Уничтожаем меню
            GameObject BuildMenuObject = GameObject.FindGameObjectWithTag("BuildMenu");
            Destroy(BuildMenuObject);

            // Если это иконка-апгрейд, то нам нужно удалить старую башню
            if (isUpgrade)
            {
                tower.cell = resourceManager.getTower().cell;
                Destroy(resourceManager.getTower().gameObject);
            }
            else {
                // Приводим ячейку в построенное положение
                resourceManager.CellBuild();
                tower.cell = resourceManager.getCell().gameObject;
            }
            

            //Vector3 centerCell = resourceManager.getCell().GetComponent<BoxCollider>().bounds.center;
            //Instantiate(tower.gameObject, new Vector3(buildMenu.transform.position.x, 0.25f, buildMenu.transform.position.z), Quaternion.identity);
            //Instantiate(tower.gameObject, new Vector3(centerCell.x, 0.25f, centerCell.z), Quaternion.identity);

            // Bad code( Нужно доработать модели в соответствии с пропорциями и координатами
            // Строим башню
            switch (tower.id) {
                case 0: Instantiate(tower.gameObject, new Vector3(BuildMenuObject.transform.position.x, 0.25f, BuildMenuObject.transform.position.z), Quaternion.Euler(0f, Random.Range(0, 360), 0f)); break;
                case 1: Instantiate(tower.gameObject, new Vector3(BuildMenuObject.transform.position.x - 0.18f, 0.05f, BuildMenuObject.transform.position.z), Quaternion.identity); break;
                default: break;
            }

            // Вычитаем деньги
            resourceManager.Gold -= tower.Cost;


           

            // Удаляем ячейку из временного доступа
            resourceManager.setCell(null);
        }
    }
}
