using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEditCircleInput : MonoBehaviour
{
    public GameObject InputPanel;

    public void onClick() {
        if (InputPanel.activeInHierarchy)
            InputPanel.SetActive(false);
        else
            InputPanel.SetActive(true);
    }
}
