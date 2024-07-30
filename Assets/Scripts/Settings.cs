using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static bool ispopup;
    private void Awake(){
        ispopup=true;
    }
    public void setPopupSetting(bool b){
            ispopup=b;
    }
}
