using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DisplayData : MonoBehaviour
{
    public ArmUIManager measurementManager;
    public TextMeshProUGUI measurementList1;
    public TextMeshProUGUI measurementList2;
    private void OnEnable()
    {
        displayData();
    } 

    public void displayData()
    {
        measurementList1.text = "";
        measurementList2.text = "";
        foreach (string measurement in measurementManager.measurements)
        {
            if (measurement.Split(' ')[0] == "Fish")
            {
                measurementList1.text += measurement;
            }
            else if (measurement.Split(' ')[0] == "Coral")
            {
                measurementList2.text += measurement;
            }
        }
    }
}
