using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    private static GameController gm;


    public float animSpeedInc = 0;
    public GameObject scorePopUp;
    private int score = 0;

    public float upgradeTimer = 10;

    public int upgradeAmount = 0;
    public bool extra_enemies = false;

    public GameObject musicHolder;

    public bool playMusic = true;

    public enum GameStates {MainMenu, Game, GameOver};
    
    public GameStates gameState;

    public bool controllerType;


    public CanvasHandler canvas;
    // Start is called before the first frame update
    void Awake()
    {
        if(gm == null) {
            gm = this;
            DontDestroyOnLoad(gm);
            toMainMenu();
        }
    }


    public static GameController getInstance(){
        return gm;
    }

    public bool extraEnemies() {
        return extra_enemies;
    }


    public void scorePoints(int i, Vector3 pos) {
        score += i;
        canvas.updateScore(score);
        GameObject popUp = Instantiate(scorePopUp, pos, Quaternion.identity);
        popUp.GetComponent<ScorePopupObject>().setScore(i);
    } 

    public void updateHealth(int health) {
        canvas.updateLives(health);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameStates.Game) {
            GameLogic();
        } else if(gameState == GameStates.MainMenu) {

        } else if(gameState == GameStates.GameOver) {

        }
    }




    public void GameLogic() {
        
        if(upgradeTimer <=0) {
            animSpeedInc += 0.1f;
            upgradeTimer += 10;
            upgradeAmount += 1;

        }
        upgradeTimer -= Time.deltaTime;

        if(!extra_enemies && upgradeAmount >= 4) {
            extra_enemies= true;
            animSpeedInc = 0.3f;
        }
        if(!musicHolder.GetComponent<AudioSource>().isPlaying && playMusic) {
            musicHolder.GetComponent<AudioSource>().Play();
        } else if(!playMusic) {
            musicHolder.GetComponent<AudioSource>().Stop();
        }
    }

    public bool getControllerType() {
        return controllerType;
    }

    public void ChangeStates(GameStates g) {
        gameState = g;
        if(gameState == GameStates.Game) {
            canvas.initializeGame();
        } else if(gameState == GameStates.MainMenu) {
            canvas.initializeMainMenu();
        } else if(gameState == GameStates.GameOver) {
            canvas.initializeGameOver();
        }
    }

    public void setControllerType(bool type) {
        controllerType = type;
    }

    public void resetGame() {
        musicHolder.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene("MainMenu");
        int hs = PlayerPrefs.GetInt("HighScore");
        if(score > hs) {
            PlayerPrefs.SetInt("HighScore", score);
            
        }
        canvas.updateGameOver(score);
        ChangeStates(GameStates.GameOver);
       
            GetComponent<AudioSource>().Play();
        }

    public void startGame() {

        Debug.Log("This is running");
        ChangeStates(GameStates.Game);
        SceneManager.LoadScene("SampleScene");
        animSpeedInc = 0.1f;
        score = 0;
        canvas.updateScore(score);
        canvas.updateLives(3);
         if(playMusic) {
            musicHolder.GetComponent<AudioSource>().Play();
         }
    }


    public void toMainMenu() {
        ChangeStates(GameStates.MainMenu);
        SceneManager.LoadScene("MainMenu");
        canvas.updateMainMenuScore(PlayerPrefs.GetInt("HighScore"));
    }


    public float getAnimSpeedInc() {
        return animSpeedInc;
    }

}
