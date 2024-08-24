using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newgame : MonoBehaviour
{
    public void _new_game(){
        if(GameManager.Instance!=null){
            GameManager.Instance.NewGame();
        }
        else{
            Debug.Log("no gamemanager? new game?");
        }
    }
}
