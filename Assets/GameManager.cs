using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Score { get; private set; }

    public int EssenceScore { get; private set; }
    public int Lives { get; private set; }

    // Consider storing level data and scores in a more complex structure or database for actual leaderboards
    public Dictionary<string, int> highScores = new Dictionary<string, int>();
    
    void Update(){
        HandleGlobalInputs();
    }

    private void HandleGlobalInputs()
    {
        // Check for global input events, like pausing the game.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_STANDALONE
                Application.Quit();
            #endif
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }

        // More global input checks can be added here.
    }
    void Awake()
    {
        // Implementing Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize the game state
        ResetGame();
    }

    public void AddEssenceScore(int amount)
    {
        EssenceScore += amount;
        // Update the score UI (assuming a method like this exists)

        UIManager.Instance.UpdateEssenceCount(EssenceScore);
        Debug.Log("Current Score: " + EssenceScore);
    }

    // public void LoseLife()
    // 
    //     Lives--;
    //     if (Lives <= 0)
    //     {
    //         // Handle game over (restart the level, show game over screen, etc.)
    //         GameOver();
    //     }
    //     else
    //     {
    //         // Update lives UI
    //         UIManager.Instance.UpdateLivesUI(Lives);
    //     }
    // }

    public void RestartLevel()
    {
        // Reset score and lives if needed
        // Load the current level again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        // Increment level index and load next level
        // Placeholder for actual level loading logic
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.Log("No More levels");
            // No more levels, maybe loop back to start or show end-game content
        }
    }

    public void SaveHighScore(string levelName, int score)
    {
        if (highScores.ContainsKey(levelName))
        {
            if (score > highScores[levelName])
            {
                highScores[levelName] = score;
                // Save the new high score
                PlayerPrefs.SetInt(levelName + "_highscore", score);
                PlayerPrefs.Save();
            }
        }
        else
        {
            highScores.Add(levelName, score);
            PlayerPrefs.SetInt(levelName + "_highscore", score);
            PlayerPrefs.Save();
        }
    }

    private void ResetGame()
    {
        Score = 0;
        Lives = 3; // Or whatever the starting lives should be
        // Update UI for score and lives
        // UIManager.Instance.UpdateScoreUI(Score);
        // UIManager.Instance.UpdateLivesUI(Lives);
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        // Placeholder for actual game over logic
        // For example, show the game over UI, stop gameplay, etc.
        // UIManager.Instance.ShowGameOverScreen();
    }

    // Other game management methods...
}