using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager sharedInstance;
    public Canvas gameCanvas;
    public Canvas pauseCanvas;
    public Canvas gameOverCanvas;
    //    public Canvas extraLifeCanvas;


    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Funciones para mostrar u ocultar el canvas del juego
    public void ShowGameCanvas()
    {
        gameCanvas.enabled = true;
    }
    public void HaidGameCanvas()
    {
        gameCanvas.enabled = false;
    }

    // Funciones para mostrar u oculatra el canvas de la pausa
    public void ShowPauseCanvas()
    {
        pauseCanvas.enabled = true;
    }
    public void HaidPauseCanvas()
    {
        pauseCanvas.enabled = false;
    }

    // Funciones para mostrar u oculatra el canvas del Game Over
    public void ShowGameOverCanvas()
    {
        gameOverCanvas.enabled = true;
    }
    public void HaidGameOverCanvas()
    {
        gameOverCanvas.enabled = false;
    }

    // Funciones para mostrar u oculatra el canvas de Extra Life
    /*   public void ShowExtraLifeCanvas()
       {
           extraLifeCanvas.enabled = true;
       }
       public void HaidExtraLifeCanvas()
       {
           extraLifeCanvas.enabled = false;
       } */

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

    }
}
