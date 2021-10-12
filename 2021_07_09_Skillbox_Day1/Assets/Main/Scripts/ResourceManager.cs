using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ResourceManager : MonoBehaviour
{
    public int Lifes;
    public int Gold;

    public Text gameOverTxt;

    private Cell cell;
    private Tower tower;

    void Update()
    {
        if (Lifes <= 0) {
            gameOverTxt.gameObject.SetActive(true);
        }
    }

    public void setCell(Cell cell) {
        this.cell = cell;
    }

    public Cell getCell()
    {
        return cell;
    }

    public void setTower(Tower tower)
    {
        this.tower = tower;
    }

    public Tower getTower()
    {
        return tower;
    }

    public void CellDefault() {
        cell.OpenedBuildMenu = false;
        cell.GetComponent<Renderer>().material = cell.MainMaterial;
    }

    public void CellBuild()
    {
        cell.CreatedTower = true;
        CellDefault();
    }

    public void TowerSell() 
    {
        cell = tower.cell.GetComponent<Cell>();
        cell.CreatedTower = false;
        setTower(null);
    }


}
