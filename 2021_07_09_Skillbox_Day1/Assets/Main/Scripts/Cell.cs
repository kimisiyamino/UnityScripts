using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    // Материалы для ячейки: Основной, Можно строить, Нельзя строить, Открыто меню
    public Material MainMaterial;
    public Material OverMaterial;
    public Material StopMaterial;
    public Material BuildMaterial;

    // Можно ли строить здесь
    public bool CanBuild;
    // Открыто ли меню здесь
    public bool OpenedBuildMenu;
    // Построена ли тут башня?
    public bool CreatedTower;

    // Префаб Меню
    public GameObject BuildMenuPrefab;
    // ResourceManager
    private ResourceManager resourceManager;
    // Объект camera для создания меню с поворотом относительно MainCamera
    private GameObject cameraPos;


    void Start()
    {
   
        resourceManager = FindObjectOfType<ResourceManager>();
        cameraPos = GameObject.FindGameObjectWithTag("CameraObject");
    }

    private void OnMouseDown()
    {
        if (Pause.isPause)
        {
            return;
        }

        if (!CreatedTower)
        {
            // Если в этой ячейке можно строить
            if (CanBuild)
            {
                GameObject BuildMenuObject = GameObject.FindGameObjectWithTag("BuildMenu");
                
                // Открыто или закрыто меню здесь?
                if (OpenedBuildMenu)
                {
                    // Закрываем
                    OpenedBuildMenu = false;
                    // Удаляем меню
                    Destroy(BuildMenuObject);
                }
                else
                {
                    // Есть ли вообще открытое меню?
                    if (BuildMenuObject)
                    {
                        
                        // Удаляем меню
                        Destroy(BuildMenuObject);
                        // Приводим к исходному состоянию ячейку, где было открыто меню
                        if (resourceManager.getCell() != null)
                            resourceManager.CellDefault();
                        if (resourceManager.getTower() != null)
                            resourceManager.getTower().OpenedMenu = false;

                    }

                    // Создаём меню на текущей ячейке 
                    Instantiate(BuildMenuPrefab, new Vector3(transform.position.x, 3f, transform.position.z), Quaternion.Euler(45f, cameraPos.transform.eulerAngles.y + 90f, 0f));
                    // Меню открытоv
                    OpenedBuildMenu = true;
                    // и сохраняем эту ячейку, что бы потом на её координатах построить башню
                    resourceManager.setCell(this);
                    // Делаем цвет ячейки желтым
                    GetComponent<Renderer>().material = BuildMaterial;
                }
            }
           // print("CanBuild: " + CanBuild);
          //  print("OpenedBuildMenu: " + OpenedBuildMenu);
          //  print("CreatedTower: " + CreatedTower);
        }
    }

    // При наведении mouse
    private void OnMouseOver()
    {
        if (Pause.isPause) {
            return;
        }

        if (!CreatedTower)
        {
            // Если можно строить и меню не открыто
            if (CanBuild && !OpenedBuildMenu)
            {
                GetComponent<Renderer>().material = OverMaterial;
            }// Если нельзя строить и меню не открыто
            else if (!CanBuild && !OpenedBuildMenu)
            {
                GetComponent<Renderer>().material = StopMaterial;
            }
        }
    }

    private void OnMouseExit()
    {
        if (Pause.isPause)
        {
            return;
        }

        // Если меню не открыто
        if (!CreatedTower)
            if (!OpenedBuildMenu)
                GetComponent<Renderer>().material = MainMaterial;
    }
}
