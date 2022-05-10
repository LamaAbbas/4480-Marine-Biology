using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MenuBoxes{
    Scene, Settings, MM, Exit
}
public class OnMenuSelect : MonoBehaviour
{
    public MenuBoxes boxtype;
    public GameObject PanelMenu;
    public GameObject boxBack;
    
    public void OnCollisionEnter(Collision other){
        if (other.transform.gameObject.tag == "Player"){
            Debug.Log("Player touched box");
            PanelMenu.SetActive(true);
            boxBack.SetActive(true);
        }
    }

    public void CloseMenu(){
        boxBack.SetActive(false);
        PanelMenu.SetActive(false);
    }
}
