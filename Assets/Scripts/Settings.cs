using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public void setPopupSetting(bool b){
        GameManager.Instance.ispopup=b;
    }
}
