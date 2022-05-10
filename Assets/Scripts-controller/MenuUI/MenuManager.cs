using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject panelBack;
    // Just for Title Screen
    public GameObject settingsPanel;
    public GameObject TitlePanel;
    public void OnLagoon(){
        SceneManager.LoadScene("Lagoon");
    }
    public void OnKelp(){
        SceneManager.LoadScene("Kelp forest");
    }
    public void OnMM(){
        SceneManager.LoadScene("TitleScreen");
    }
    public void OnExit(){
        Application.Quit();
    }

    public void OnSettings(){
        TitlePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void onCloseSettings(){
        settingsPanel.SetActive(false);
        TitlePanel.SetActive(true);
    }
    public void OnPlay(){
        SceneManager.LoadScene("Lagoon");
    }

}
