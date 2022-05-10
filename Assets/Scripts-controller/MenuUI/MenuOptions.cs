using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class MenuOptions : MonoBehaviour
{
    [SerializeField] XRNode node;
    [SerializeField] private XRController lController;
    private bool menuOpen;
    private bool openMenu;
    private bool openMenu2;
    private bool closeMenu;
    private int menuButtonPressed;
    [SerializeField] GameObject menu;

    private bool buttonWasPressed;
    // Start is called before the first frame update
    void Start()
    {
        XRSettings.eyeTextureResolutionScale = 1.5f;
        menuOpen = false;
        menu.SetActive(false);
        menuButtonPressed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(node);
        device.TryGetFeatureValue(CommonUsages.secondaryButton, out openMenu);
        device.TryGetFeatureValue(CommonUsages.primaryButton, out closeMenu);
        device.TryGetFeatureValue(CommonUsages.menuButton, out openMenu2);

        if (openMenu2 && !buttonWasPressed){
            buttonWasPressed = true;
            if (menuButtonPressed == 0){
                menuButtonPressed = 1;
            }
            else{
                menuButtonPressed = 0;
            }
        }
        else if (!openMenu2){
            buttonWasPressed = false;
        }


        if (openMenu || (buttonWasPressed && menuButtonPressed == 0)){
            
            Debug.Log("Y was pressed");
            closeMenu = false;
            menu.SetActive(true);
        }
        else if (closeMenu || (buttonWasPressed && menuButtonPressed == 1)){
            
            Debug.Log("X Was Pressed");
            openMenu = false;
            menu.SetActive(false);
        }
    }

}
