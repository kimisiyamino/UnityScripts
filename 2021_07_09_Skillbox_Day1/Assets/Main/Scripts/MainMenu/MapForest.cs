using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapForest : MonoBehaviour
{
    public string Map;

    void OnMouseOver()
    {
        transform.localScale = new Vector3(1f, 1f, transform.localScale.z);
    }

    void OnMouseExit()
    {
        transform.localScale = new Vector3(0.62f, 0.62f, transform.localScale.z);
    }

    void OnMouseUp()
    {
        SceneManager.LoadScene(Map, LoadSceneMode.Single);
    }
}
