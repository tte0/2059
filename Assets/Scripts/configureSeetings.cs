using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class configureSeetings : MonoBehaviour
{
    public void _setpopup(bool b){
        if(Settings.Instance!=null){
            Debug.Log("setting up...");
            Settings.Instance.setPopupSetting(b);
        }
        else{
            Debug.Log("no settings? settings?");
        }
    }
}
