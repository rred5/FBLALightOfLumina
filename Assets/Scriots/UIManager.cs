using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // If you're using TextMeshPro

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    // public Text scoreText; // If you're using standard UI Text
    // public TextMeshProUGUI scoreText; // Uncomment if you're using TextMeshPro

    bool gameDone = false;
    public GameObject scorePanel; // The parent panel containing the score UI
    public GameObject timePanel; // Panel for showing time

    public GameObject essenceScorePanel;
    public TextMeshProUGUI timeText; 
    
    public GameObject GameOverPanel;

    public TextMeshProUGUI totalScore;

    public TextMeshProUGUI winState;

    public bool initializeElements;
    public TextMeshProUGUI essenceScoreText;// Text element to display time within the TimePanel
    // public TextMeshProUGUI timeText; // Uncomment if you're using TextMeshPro
     // Panel for showing essence-related messages or count

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // public void UpdateScoreUI(int score)
    // {
    //     scoreText.text = score.ToString();
    // }   
    public void setEssenceScoreText(TextMeshProUGUI inputEssenceText){
        essenceScoreText = inputEssenceText;
    }
    public void setTimeScoreText(TextMeshProUGUI inputTimeText){
        timeText = inputTimeText;
    }

    public void setScorePanel(GameObject inputScorePanel){
        scorePanel = inputScorePanel;
    }

    public void setGameOverPanel(GameObject inputOverPanel){
        GameOverPanel = inputOverPanel;
    }
    
    public void setTotalScore(TextMeshProUGUI inputTotalScore){
        totalScore = inputTotalScore;
    }

    public void setStateWin(TextMeshProUGUI ifWin){
        winState = ifWin;
    }


    public void UpdateTimeUI(float time)
    {
        timeText.text = (time.ToString("F2")); // F2 formats the float to show only two decimal places
    }

    // Method to display essence dialogue or count
    public void UpdateEssenceCount(int count)
    {
        if (essenceScoreText.text != null)
        {
            essenceScoreText.text = count.ToString();
        }
    }

    
    public void initalizeUIElements(bool input){
        initializeElements = input;
    }

    public bool checkInitializeUIElements(){
        return initializeElements;
    }

    public void updateScoreUI(float score){
        totalScore.text = ("Score: " + score.ToString());
    }
    public void ShowGameOverScreen(bool win){
        gameDone = true;
        GameOverPanel.SetActive(true);
        updateScoreUI(GameManager.Instance.calculateScore());
        if(win){
            winState.text = "You Won!";  
        }
        else{
            winState.text = "You Lost!"; 
        }
    }

    public bool getGameDone(){
        return gameDone;
    }
}
