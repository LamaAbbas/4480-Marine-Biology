using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class handpresence : MonoBehaviour
{
    public enum handController{
        left, right
    }
    [SerializeField] handController handDir;
    private InputDevice targetDev;
    InputDeviceCharacteristics controllerC;
    Animator hand_anim;
    // Start is called before the first frame update
    void Start()
    {
        initializeHands();
    }
    void initializeHands(){
        hand_anim = GetComponent<Animator>();
        List<InputDevice> devices = new List<InputDevice>();
        
        if (handDir == handController.right){
           controllerC = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller; 
        }
        else if (handDir == handController.left){
           controllerC = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;  
        }
        
        
        InputDevices.GetDevicesWithCharacteristics(controllerC, devices);
        foreach (var dev in devices){
            Debug.Log(dev.name +","+ dev.characteristics );
        }
        if (devices.Count >0){
            targetDev = devices[0];
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!targetDev.isValid){
            initializeHands();
        }
        
        if (targetDev.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonVal) && primaryButtonVal){
            Debug.Log("Primary Button Pressed");
        }
            
        if (targetDev.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) &&triggerValue > 0.1f ){
            Debug.Log("Trigger pulled");
            hand_anim.SetFloat("trigger", triggerValue);
        }
        else{
            hand_anim.SetFloat("trigger", 0);
        }
        if (targetDev.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f ){
            Debug.Log("Grip pulled");
            hand_anim.SetFloat("grip", gripValue);
        }
        else{
            hand_anim.SetFloat("grip", 0);
        }
        if (targetDev.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxis) && primary2DAxis != Vector2.zero){
            Debug.Log("Stick Moved");
        }

    }
}
