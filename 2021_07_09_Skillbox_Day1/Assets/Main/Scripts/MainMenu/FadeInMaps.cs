using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInMaps : MonoBehaviour
{
    public Animator[] maps;
    public Animator buttonBack;
    public Animator camera;
    public Animator buttonsMain;

    IEnumerator ShowMaps() {
        buttonsMain.Play("fadeoutMenu");
        camera.Play("CameraLevel");
        yield return new WaitForSeconds(2.2f);
        foreach (Animator map in maps) 
        {
            map.gameObject.SetActive(true);
            map.Play("fadeInMap");
        }
        buttonBack.Play("backButtonFadeIn");
    }

    IEnumerator HideMaps()
    {
        foreach (Animator map in maps)
        {
            map.gameObject.SetActive(false);
            map.Play("fadeOutMap");
        }
        buttonBack.Play("backButtonFadeOut");
        camera.Play("CameraMain");
        yield return new WaitForSeconds(2.2f);

        buttonsMain.Play("fadeInMenu");
    }

    IEnumerator GameQuit()
    {
        buttonsMain.Play("fadeoutMenu");
        camera.Play("CameraLevel");
        yield return new WaitForSeconds(2.2f);
        Application.Quit();
    }

    public void Show() 
    {
        StartCoroutine(ShowMaps());
    }

    public void Hide()
    {
        StartCoroutine(HideMaps());
    }

    public void Quit()
    {
        StartCoroutine(GameQuit());
    }
    
}
