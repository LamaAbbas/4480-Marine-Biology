using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class ArmUIManager : MonoBehaviour
{
    [SerializeField] XRNode node;

    public GameObject selectedQuadrant=null;
    public GameObject selectedCircleArea=null;


    public int fishMeasurement = 0;
    public float coralMeasurement =0;
    public Text fishValue, coralValue;
    public Slider coralUI;

    public List<GameObject> regions;
    public int numRegions;
    public Text regionDisplay;
    public int selectedRegionIndex=-1;

    public List<string> measurements;
    private void Start()
    {
        measurements = new List<String>();
        regionDisplay.text = "Select region";
    }


    bool pressInteractButton = false;



    public void OnTriggerEnter(Collider other){
        selectQuadrant(other.transform.parent.gameObject);
    }
    //---TO BE CALLED WHEN TELEPORTING TO QUADRANT / CIRCLE AREA---
    // --- PERHAPS CHARACTER HAS LARGE TRIGGER THAT CHECKS IF ITS INTERSECTING WITH A QUADRANT, IF SO SELECTS THAT QUADRANT HERE
    public void selectQuadrant(GameObject g){
        selectedQuadrant=g;
        selectedCircleArea=null;
    }
    public void selectCircleArea(GameObject g){
        g.GetComponent<SampleCounter>().selectThis();
        selectedCircleArea = g;
        selectedQuadrant=null;  
    }


    //FISH
    public void incFishMeasur()
    {
        fishMeasurement += 1;
        fishValue.text = "Count: " + fishMeasurement;
    }
    public void decFishMeasur()
    {
        if (fishMeasurement > 0)
        {
            fishMeasurement -= 1;
            fishValue.text = "Count: " + fishMeasurement;
        }
    }
    public void confirmFishMeasur()
    {
        WriteLine(selectedCircleArea, "Fish Measurement: " + fishMeasurement);
        string data = "Fish Measurement: " + fishMeasurement;
        if (selectedCircleArea)
        {
            data = data + " " + selectedCircleArea.name;
        }
        measurements.Add(data);
        fishValue.text = "Confirmed!";
        fishMeasurement = 0;
        selectedCircleArea.GetComponent<SampleCounter>().unselectThis();

    }
    //CORAL
    public void updateCoralMeasur()
    {
        coralMeasurement = coralUI.value;
        coralValue.text = "Level: " + coralMeasurement + "%";
        
    }
    public void confirmCoralMeasur()
    {
        WriteLine(selectedQuadrant, "Coral Measurement: " + coralMeasurement + "%");
        string data = "Coral Measurement: " + coralMeasurement + "%";
        if (selectedQuadrant)
        {
            data = data + " " + selectedQuadrant.name;

        }
        measurements.Add(data);
        coralValue.text = "Confirmed!";
        coralMeasurement = 0;
        
    }


    //SELECT REGION
    public void region_plus()
    {
        selectedRegionIndex += 1;
        if(selectedRegionIndex >= numRegions)
        {
            selectedRegionIndex = 0;
        }
        foreach(GameObject region in regions)
        {
            region.GetComponent<SampleCounter>().unselectThis();
        }
        selectCircleArea(regions[selectedRegionIndex]);

        regionDisplay.text = "Region " + selectedRegionIndex;
    }
    public void region_minus()
    {
        selectedRegionIndex -= 1;
        if (selectedRegionIndex <0)
        {
            selectedRegionIndex = numRegions-1;
        }
        foreach (GameObject region in regions)
        {
            region.GetComponent<SampleCounter>().unselectThis();
        }
        selectCircleArea(regions[selectedRegionIndex]);

        regionDisplay.text = "Region " + selectedRegionIndex;
    }

    public static bool WriteLine (GameObject quadArea, string data)
     {
        Debug.Log(Application.persistentDataPath);
        string fileName = "marineData.txt";
        string path = Application.persistentDataPath;

        if(quadArea==null){
            data = "unset quadrant/circlearea " + data;
           
        }
        else{
            
            data = quadArea.name + " " + data + "\n";
            
        }

         bool retValue = false;
         try {
             if (!Directory.Exists (path))
                 Directory.CreateDirectory (path);
             System.IO.File.AppendAllText (path + fileName, data);
             retValue = true;
         } catch (System.Exception ex) {
             string ErrorMessages = "File Write Error\n" + ex.Message;
             retValue = false;
             Debug.LogError (ErrorMessages);
         }
         return retValue;
     }


    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(node);
        device.TryGetFeatureValue(CommonUsages.secondaryButton, out pressInteractButton);
        
    }
}

