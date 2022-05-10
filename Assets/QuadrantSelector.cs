using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadrantSelector : MonoBehaviour
{
    public ArmUIManager uimanager;
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.name.Equals("arrow")){
            uimanager.selectQuadrant(other.gameObject.transform.parent.gameObject);
        }
    }
}
