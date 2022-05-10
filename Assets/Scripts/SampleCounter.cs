using UnityEngine;

public class SampleCounter : MonoBehaviour
{
    public bool selected = false;

    public float numOfFish = 0;
    public Color selectedColor, normalColor;

    public void unselectThis()
    {
        selected = false;
        this.GetComponent<Renderer>().material.color = normalColor;
    }
    public void selectThis() {
        //iterate through sample areas and unselect
        selected = true;
        this.GetComponent<Renderer>().material.color = selectedColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (selected)
        {
            print(other.name + " enetered");
            if (other.tag == "Boid")
            {
                numOfFish++;
                Outline instance = other.GetComponent<Outline>();
                if (instance)
                {
                    instance.OutlineWidth = 5f;
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
            if (other.tag == "Boid")
            {
                Outline instance = other.GetComponent<Outline>();
                if (instance)
                {
                    instance.OutlineWidth = 0f;
                }
            }

    }


}
