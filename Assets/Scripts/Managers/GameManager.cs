using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    pause,
    gameOver,
    extraLife,
    shop,
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.inGame;
    public static GameManager sharedInstance;

    private PlayerController controller;

    public bool gameRunning = true;

    private void Awake()
    {
        //El if solo es para asegurar que solo hay un shared Instance
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.inGame)
        {
            StartGame();
        }

        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeGameRunningState();
        }*/
    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void Pause()
    {
        SetGameState(GameState.pause);
    }

    public void gameOver()
    {
        SetGameState(GameState.gameOver);
    }


    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.inGame)
        {
            // TODO: Hay que programar la escena para jugar
            LevelManager.sharedInstance.RemoveLevelBlocks();

            // Invoca a la funcion ("ReloadLevel, despues de .1 seg)
            Invoke("ReloadLevel", 0.1f);

            MenuManager.sharedInstance.ShowGameCanvas();
            MenuManager.sharedInstance.HaidGameOverCanvas();
            MenuManager.sharedInstance.HaidPauseCanvas();
        }
        else if (newGameState == GameState.gameOver)
        {
            // TODO: Preparar el juego para el Game Over
            MenuManager.sharedInstance.HaidGameCanvas();
            MenuManager.sharedInstance.ShowGameOverCanvas();
            MenuManager.sharedInstance.HaidPauseCanvas();

            //Time.timeScale = 0f;
        }
        else if (newGameState == GameState.pause)
        {
            // TODO: Preparar el juego para el Game Over
            MenuManager.sharedInstance.HaidGameCanvas();
            MenuManager.sharedInstance.HaidGameOverCanvas();
            MenuManager.sharedInstance.ShowPauseCanvas();
        }
        else if (newGameState == GameState.extraLife)
        {
            // TODO: Preparar el juego para el Game Over
            MenuManager.sharedInstance.HaidGameCanvas();
            MenuManager.sharedInstance.HaidGameOverCanvas();
            MenuManager.sharedInstance.HaidPauseCanvas();
        }

        this.currentGameState = newGameState;
    }

    public void ReloadLevel()
    {
        LevelManager.sharedInstance.GenerateInitialBlocks();
        controller.StartGame();
    }

    // Las siguientes funciones serán para poder pausar el jueg
    // conuncambio de variables
    public void ChangeGameRunningState()
    {
        gameRunning = !gameRunning;

        if (gameRunning)
        {
            Time.timeScale = 1f;
            MenuManager.sharedInstance.HaidPauseCanvas();
            MenuManager.sharedInstance.ShowGameCanvas();

        }
        else
        {
            Time.timeScale = 0f;
            MenuManager.sharedInstance.HaidGameCanvas();
            MenuManager.sharedInstance.ShowPauseCanvas();
        }

    }

}
