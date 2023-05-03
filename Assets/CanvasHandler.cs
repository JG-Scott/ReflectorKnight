using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasHandler : MonoBehaviour
{

    public TMP_Text scoreText; 

    public TMP_Text livesText;

    public TMP_Text GameOverScoreText;

    public TMP_Text GameOverHighScoreText;

    public TMP_Text MainMenuHighScoreText;





    public GameObject GameUI;
    public GameObject MainMenuUI;
    public GameObject GameOverUI;

    public GameObject Instructions;

    
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }



    public void initializeGame() {
        GameOverUI.SetActive(false);
        GameUI.SetActive(true);
        MainMenuUI.SetActive(false);
        Instructions.SetActive(false);
    }

    public void initializeGameOver() {
        GameOverUI.SetActive(true);
        GameUI.SetActive(false);
        MainMenuUI.SetActive(false);
        Instructions.SetActive(false);
    }

    public void initializeMainMenu() {
        GameOverUI.SetActive(false);
        GameUI.SetActive(false);
        MainMenuUI.SetActive(true);
        Instructions.SetActive(false);

    }
    public void initializeInstructions() {
        GameOverUI.SetActive(false);
        GameUI.SetActive(false);
        MainMenuUI.SetActive(false);
        Instructions.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateScore(int score) {
        scoreText.text = "Score: " + score;
    }

    public void updateLives(int lives) {
        livesText.text = "Lives: " + lives;
    }

    public void updateMainMenuScore(int highscore) {
        MainMenuHighScoreText.text = "High Score: " + highscore;
    }


    public void updateGameOver(int score) {
        GameOverScoreText.text = "Score: " + score;
        GameOverHighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }


}
