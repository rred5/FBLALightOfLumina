using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScorePanelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI timePanelText;
    public TextMeshProUGUI essencePanelText;

    public GameObject ScorePanelObj;

    public GameObject GameOverPanel;

    public TextMeshProUGUI scoreGui;

    public TextMeshProUGUI winnerCheck;
    void initScoreUpdate(){
        UIManager.Instance.setEssenceScoreText(essencePanelText);
         UIManager.Instance.setTimeScoreText(timePanelText);
          UIManager.Instance.setScorePanel(ScorePanelObj);
        UIManager.Instance.setGameOverPanel(GameOverPanel);
        UIManager.Instance.setStateWin(winnerCheck);
        UIManager.Instance.setTotalScore(scoreGui);
    }


    void Start()
    {
        initScoreUpdate();
    }

    // Update is called once per frame
    void Update()
    {
    if(!UIManager.Instance.getGameDone()){
        GameManager.Instance.AddTimeScore(GameManager.Instance.getTimeScore());
    }
    }
    
}
