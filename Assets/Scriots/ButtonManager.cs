using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnNextLevelButtonClicked()
    {
        // Check if GameManager exists before calling LoadNextLevel
     
        GameManager.Instance.LoadNextLevel();
       

    }
}

