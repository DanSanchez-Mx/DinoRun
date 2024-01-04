using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameView : MonoBehaviour
{
    public TextMeshProUGUI /* coinsText, */ scoreText, highScoreText;

    private float score;
    private float highScore;

    private PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        controller = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score > highScore)
            Save();

        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            //int coins = GameManager.sharedInstance.collectedObject;
            score = controller.GetTravelDistance();

            //coinsText.text = coins.ToString();
            scoreText.text = "" + score.ToString("f2");
            highScoreText.text = "" + highScore.ToString("f2");
        }
    }

    void Save()
    {
        PlayerPrefs.SetFloat("HighScore", score);

        highScore = score;
        highScoreText.text = "" + highScore.ToString("0");
    }
}