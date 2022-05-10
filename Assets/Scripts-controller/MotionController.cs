using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class MotionController : MonoBehaviour
{
    [SerializeField] XRNode node;
    float speed = 2f;
    private Vector2 inputAxis;
    private float triggerAxis;
    private CharacterController character;
    private float height = 0.2f;
    private XRRig rig;
    [SerializeField] private XRController lController;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveController();
        InputDevice device = InputDevices.GetDeviceAtXRNode(node);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        device.TryGetFeatureValue(CommonUsages.trigger, out triggerAxis);
    }

    void FixedUpdate()
    {
        Quaternion yaw = Quaternion.Euler(0, lController.transform.eulerAngles.y,0);

        Quaternion pitch = Quaternion.Euler(0,0,0);
        
        if (triggerAxis >= 0.1f){
            pitch.x =  lController.transform.localRotation.x;
        }
        
        
        Vector3 dir = yaw * pitch * new Vector3(inputAxis.x, 0, inputAxis.y);
        
        character.Move(dir * Time.deltaTime * speed);
    }

    void MoveController(){
        character.height = rig.cameraInRigSpaceHeight + height;
        Vector3 charCentre = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(charCentre.x, character.height/2 + character.skinWidth, charCentre.z);
    }
}
