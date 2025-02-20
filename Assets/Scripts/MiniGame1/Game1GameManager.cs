using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game1GameManager : MonoBehaviour
{
    static Game1GameManager game1GameManager;

    public static Game1GameManager Instance 
    { 
        get {return game1GameManager;}
    }

    private int currentScore = 0;

    private void Awake()
    {
        game1GameManager = this;
    }

    public void GameOver() 
    {
        Debug.Log("Game Over");
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene("Minigame1");
    }
    public void EndGame() 
    {
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score) 
    {
        Debug.Log("Score: " + currentScore);
    }
}
