using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private string _sceneMain="mainmenu";
    private string _sceneSettings="settings";
    private string _sceneCredits="credits";
    private string _sceneGame="2048";
    
    public void changeToMainMenu(){
        SceneManager.LoadScene(_sceneMain);
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

}
