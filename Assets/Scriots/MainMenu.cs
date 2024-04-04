using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void playGame(){
    SceneManager.LoadScene(1);
   }

   public void openSettingsMenu(){
    SceneManager.LoadScene("SettingsMenu");
   }

   public void openMainMenu(){
    SceneManager.LoadScene("MainMenu");
   }
   public void quitGame(){
    #if UNITY_STANDALONE
        Application.Quit();
    #endif
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
   }
}
