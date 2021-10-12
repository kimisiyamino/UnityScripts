using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // id (для индивидуальности башен)
    public int id;
    // Радиус, Урон, КД (Cooldown) константа
    public float Radius, Damage, FireDelay;
    // Цена башни (так же входит апгрейденные башни)
    public int Cost;


    // Оружие, Патрон, точка выстрела, конечная точка радиуса выстрела
    public Transform bulletPrefab;
    private Transform gun, firePoint, firePointEnd;

    
    // Противник и слой противника, если он в пределах радиуса
    public Transform enemy;
    public LayerMask EnemyLayer;


    // Меню башни
    public GameObject EditTowerMenu;
    public bool OpenedMenu;

    public GameObject cell;


    // ResourceManager, Объект camera для создания меню с поворотом относительно MainCamera, Переменная счётик времени для КД
    private ResourceManager resourceManager;
    private GameObject camera;
    private float timeToFire;

    void Start()
    {
        timeToFire = FireDelay;
        gun = transform.GetChild(0);
        firePoint = gun.GetChild(0);

        firePointEnd = gun.GetChild(2);

        resourceManager = FindObjectOfType<ResourceManager>();
        camera = GameObject.FindGameObjectWithTag("CameraObject");
    }

    void Update()
    {
        Vector3 rayDirection = firePointEnd.position - firePoint.position;
        

        if (timeToFire > 0)
        {
            timeToFire -= Time.deltaTime;
        }
        else if(enemy && timeToFire <= 0) {
            Fire();    
        }

        if (enemy)
        {

            Debug.DrawRay(firePoint.position, enemy.position - firePoint.position, Color.red);

            // Вектор направления
            Vector3 lookAt = enemy.position - gun.position; 

            // Поворот к противнику, следим по x и z координатам противника
            gun.transform.rotation = Quaternion.LookRotation(new Vector3(lookAt.x, 0, lookAt.z)); // 

            // Если дистанция между башней и противником больше радиуса 
            if (Vector3.Distance(transform.position, enemy.position) > Radius)
            {
                enemy = null;
            }
        }
        else if (enemy == null)
        {

            Debug.DrawRay(firePoint.position, rayDirection, Color.blue);

            // Сфера, которая ищет все коллайдеры на слое
            Collider[] colliders = Physics.OverlapSphere(transform.position, Radius, EnemyLayer);

            // Если есть хотя бы 1 найденный коллайдер
            if (colliders.Length > 0) {
                enemy = colliders[0].transform;
            }
        }
    }

    private void Fire() {
        Transform bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.LookAt(enemy.GetComponent<BoxCollider>().bounds.center);
        bullet.GetComponent<Bullet>().Damage = Damage; 

        timeToFire = FireDelay;
    }

    private void OnMouseUp()
    {
        if (Pause.isPause)
        {
            return;
        }

        GameObject BuildMenuObject = GameObject.FindGameObjectWithTag("BuildMenu");

        if (OpenedMenu)
        {
            OpenedMenu = false;
            Destroy(BuildMenuObject);
        }
        else 
        {
            // Если уже открыто меню
            if (BuildMenuObject)
            {
               
                // Удаляем меню
                Destroy(BuildMenuObject);
                // Получаем ячейку открытого меню и приводим к исходному состоянию
                if (resourceManager.getCell() != null)
                { 
                    resourceManager.CellDefault();
                }
                if (resourceManager.getTower() != null) {
                    resourceManager.getTower().OpenedMenu = false;
                }
                //resourceManager.getCell().GetComponent<Renderer>().material = resourceManager.getCell().MainMaterial;

            }
            
        
            // Создаём меню и сохраняем ячейку
            Instantiate(EditTowerMenu, new Vector3(transform.position.x, 3f, transform.position.z), Quaternion.Euler(45f, camera.transform.eulerAngles.y + 180, 0f));
            OpenedMenu = true;
            resourceManager.setTower(this);
            // Делаем цвет ячейки желтым
            //GetComponent<Renderer>().material = resourceManager.getCell().BuildMaterial;
        }
    }
}


