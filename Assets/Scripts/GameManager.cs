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

    void Awake() 
    {
        sharedInstance = this;
    }

    void Start() 
    {
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
                menuCanvas.enabled = true;
                break;
            case GameState.inGame:
                menuCanvas.enabled = false;
                break;
            case GameState.gameOver:
                menuCanvas.enabled = false;
                break;
        }

        current = estado;
    }
}
