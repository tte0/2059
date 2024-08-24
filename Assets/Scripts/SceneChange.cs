using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private string _sceneMain="mainmenu";
    private string _sceneSettings="settings";
    private string _sceneCredits="credits";
    private string _sceneGame="2048";
    
    public void changeToMainMenu(){
        if(GameManager.Instance.ispopupactive){
            GameObject popup = GameObject.Find("Popup");
            if (popup != null){
                Popup popupScript = popup.GetComponent<Popup>();
                popupScript.ClosePopup();
            }
            else{
                Debug.Log("no popup while esc");
            }
        }
        else{
            SceneManager.LoadScene(_sceneMain);
        }
    }
    public void changeToSettings(){
        SceneManager.LoadScene(_sceneSettings);
    }
    public void changeToCredits(){
        SceneManager.LoadScene(_sceneCredits);
    }
    public void changeToGame(){
        SceneManager.LoadScene(_sceneGame);
    }
    public void quitWithExitCode(int exitcode){
        Application.Quit(exitcode);
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;    
        #endif
    }
}
