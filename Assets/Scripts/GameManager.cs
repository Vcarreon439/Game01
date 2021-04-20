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
        StartGame();
    }
    // Start is called before the first frame update
    public void StartGame()
    {
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
        switch (current)
        {
            case GameState.menu:
                break;
            case GameState.inGame:
                break;
            case GameState.gameOver:
                break;
            default:
                break;
        }

        current = estado;
    }
}
