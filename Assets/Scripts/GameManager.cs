using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState 
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameState current = GameState.menu;
    public Canvas menuCanvas;
    public Canvas gamplay;
    public Canvas GameOverCanvas;

    void Awake() 
    {
        sharedInstance = this;
        menuCanvas.enabled = true;
    }

    void Start() 
    {
        menuCanvas.enabled = true;
        gamplay.enabled = false;
        GameOverCanvas.enabled = false;
        current = GameState.menu;
    }



    void Update() 
    {
        //if (!(current==GameState.inGame))
        //    if (Input.GetButtonDown("s"))
        //        StartGame();
    }

    // Start is called before the first frame update
    public void StartGame()
    {
       PlayerControler.compartido.StartGame();
       ChangeGameState(GameState.inGame);

    }

    // Update is called once per frame
    public void GameOver()
    {
        ChangeGameState(GameState.gameOver);
    }

    public void BackToMainMenu() 
    {
        ChangeGameState(GameState.menu);
    }

    void ChangeGameState(GameState estado) 
    {
        switch (estado)
        {
            case GameState.menu:
                GameOverCanvas.enabled = false;
                menuCanvas.enabled = true;
                gamplay.enabled = false;
                break;
            case GameState.inGame:
                GameOverCanvas.enabled = false;
                menuCanvas.enabled = false;
                gamplay.enabled = true;
                break;
            case GameState.gameOver:
                GameOverCanvas.enabled = true;
                menuCanvas.enabled = false;
                gamplay.enabled = false;
                break;
        }

        current = estado;
    }
}
