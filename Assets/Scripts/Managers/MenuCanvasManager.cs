using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvasManager : MonoBehaviour
{
    public static MenuCanvasManager sharedInstance;
    public Canvas MenuCanvas;
    public Canvas CreditsCanvas;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    public void ShowMenu()
    {
        MenuCanvas.enabled = true;
    }
    public void HaidMenu()
    {
        MenuCanvas.enabled = false;
    }

    public void ShowCredits()
    {
        CreditsCanvas.enabled = true;
    }
    public void HaidCredits()
    {
        CreditsCanvas.enabled = false;
    }


    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
