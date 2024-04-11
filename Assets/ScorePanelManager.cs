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

    void initScoreUpdate(){
        UIManager.Instance.setEssenceScoreText(essencePanelText);
         UIManager.Instance.setTimeScoreText(timePanelText);
          UIManager.Instance.setScorePanel(ScorePanelObj);
    }


    void Start()
    {
        initScoreUpdate();
    }

    // Update is called once per frame

    // void Update()
    // {
        
    // }
}
