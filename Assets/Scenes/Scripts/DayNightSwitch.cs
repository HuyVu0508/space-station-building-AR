using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSwitch : MonoBehaviour
{

    private ARGameManager arGameManager; 
    GameObject environmentLight;
    GameObject basePlane;    
    GameObject dayNightPlane;    
    GameObject [] greenhouseLights;

    // Awake method
    void Awake()
    {
        arGameManager = GameObject.FindObjectOfType<ARGameManager>();   
    }

    // Start is called before the first frame update
    void Start()
    {
            dayNightPlane = GameObject.Find("DayNightPlane");
            dayNightPlane.GetComponent<Renderer>().enabled = false;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnClick method
    public void OnClick()
    {
        if (arGameManager.dayNight == "day"){
            arGameManager.dayNight = "night";

            // Turn off environment light 
            environmentLight = GameObject.Find("Environment Light");
            environmentLight.GetComponent<Light>().enabled = false;
            basePlane = GameObject.Find("BasePlane");
            dayNightPlane = basePlane.transform.Find("DayNightPlane").gameObject;
            dayNightPlane.SetActive(true);

            // Turn on greenhouse light
            greenhouseLights = GameObject.FindGameObjectsWithTag("Greenhouse Light");
            if (greenhouseLights.Length > 0){  
                foreach (GameObject greenhouseLight in greenhouseLights)
                {
                    greenhouseLight.GetComponent<Light>().enabled = true;
                }            
            }            
        }

        else if (arGameManager.dayNight == "night"){
            arGameManager.dayNight = "day";

            // Turn on environment light 
            environmentLight = GameObject.Find("Environment Light");
            environmentLight.GetComponent<Light>().enabled = true;
            basePlane = GameObject.Find("BasePlane");
            dayNightPlane = basePlane.transform.Find("DayNightPlane").gameObject;
            dayNightPlane.SetActive(false);

            // Turn off greenhouse light
            greenhouseLights = GameObject.FindGameObjectsWithTag("Greenhouse Light");
            if (greenhouseLights.Length > 0){
                foreach (GameObject greenhouseLight in greenhouseLights)
                {
                    greenhouseLight.GetComponent<Light>().enabled = false;
                }            
            }               
        }        
    }
}
