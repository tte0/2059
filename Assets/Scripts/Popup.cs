using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public void ClosePopup(){
        GameObject popup = GameObject.Find("Popup");
        if(this.gameObject != null)Destroy(this.gameObject);
        else Debug.Log("Popup not found");
        GameManager.Instance.waiting=false;
        GameManager.Instance.ispopupactive=false;
    }   
}
