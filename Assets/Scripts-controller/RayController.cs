using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class RayController : MonoBehaviour
{
    private InputDevice targetDev;
    InputDeviceCharacteristics controllerC;
    [SerializeField]
    XRInteractorLineVisual teleLine;

    private GradientColorKey[] colorKey;
    private GradientAlphaKey[] alphaKey;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        controllerC = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller; 
        InputDevices.GetDevicesWithCharacteristics(controllerC, devices);

        if (devices.Count >0){
            targetDev = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {

        if ((targetDev.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) &&triggerValue > 0.1f)){
            colorKey = new GradientColorKey[2];
            colorKey[0].color = Color.red;
            colorKey[0].time = 0.0f;
            colorKey[1].color = Color.white;
            colorKey[1].time = 1.0f;

            alphaKey = new GradientAlphaKey[2];
            alphaKey[0].alpha = 1.0f;
            alphaKey[0].time = 0.0f;
            alphaKey[1].alpha = 0.0f;
            alphaKey[1].time = 1.0f;

            teleLine.validColorGradient.SetKeys(colorKey, alphaKey);
            teleLine.enabled = true;
        }
        else{
            colorKey = new GradientColorKey[2];
            colorKey[0].color = Color.green;
            colorKey[0].time = 0.0f;
            colorKey[1].color = Color.white;
            colorKey[1].time = 1.0f;

            alphaKey = new GradientAlphaKey[2];
            alphaKey[0].alpha = 1.0f;
            alphaKey[0].time = 0.0f;
            alphaKey[1].alpha = 0.0f;
            alphaKey[1].time = 1.0f;

            teleLine.validColorGradient.SetKeys(colorKey, alphaKey);

            teleLine.enabled = false;
        }
    }
}
