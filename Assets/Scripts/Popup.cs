using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClosePopup(){
        GameObject popup = GameObject.Find("Popup");
        if(this.gameObject != null)Destroy(this.gameObject);
        else Debug.Log("Popup not found");
        GameManager.Instance.waiting=false;
    }   
}
