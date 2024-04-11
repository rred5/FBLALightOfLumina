using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManagerLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scorePanelRef;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enableScoreChart();
    }

    void enableScoreChart(){
        if((!scorePanelRef.activeInHierarchy)&&UIManager.Instance.checkInitializeUIElements()){
            scorePanelRef.SetActive(true);
        }
        // else{
        //     Debug.Log("Requirement not met");
        // }
    }
}
