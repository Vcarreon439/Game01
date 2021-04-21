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
        if (Input.GetButtonDown("s"))
        {
            current = GameState.inGame;
        }
    }

    // Start is called before the first frame update
    public void StartGame()
    {
       // ChangeGameState(GameState.inGame);
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
        //switch (estado)
        //{
        //    case GameState.menu:
        //        current = GameState.menu;
        //        break;
        //    case GameState.inGame:
        //        current = GameState.inGame;
        //        break;
        //    case GameState.gameOver:
        //        current = GameState.gameOver;
        //        break;
        //    default:
        //        break;
        //}

        current = estado;
    }
}
