using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance { get; private set; }
    public bool ispopup;
    private void Awake(){
        ispopup=true;
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void setPopupSetting(bool b){
        ispopup=b;
        Debug.Log("settinged!");
    }
}
