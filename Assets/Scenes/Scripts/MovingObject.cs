using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingObject : MonoBehaviour
{
    public GameObject PlacementControllers;
    private float translateSpeed = 0.25f;
    private float rotateSpeed = 0.002f;
    private ARGameManager arGameManager; 
    private bool rotatingPassedThreshold = false;   // check whether in the previous frame if the rotating controller passed the threshold or not
    private float angleBeforePassedThreshold;
    private float angleAfterPassedThreshold;
    private Vector3 objectAngleBeforePassedThreshold;

    // Awake method
    void Awake()
    {
        arGameManager = GameObject.FindObjectOfType<ARGameManager>();   
    }    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // // Check if in build mode or play mode
        // if (arGameManager.GetMode() == "build_mode")
        // {
            // If an object is being placed, read input to transform the object
            if (arGameManager.currentPlaceableObject != null)
            {

                // Only show Slider and run ElevateObjectControl if object is spaceship or planet
                if (arGameManager.currentPlaceableObject.name.Contains("GreenhouseRawSample")){
                    // GameObject elevateSlider =  GameObject.FindObjectOfType<Slider>().gameObject;
                    GameObject elevateSlider = PlacementControllers.transform.Find("ElevateSlider").gameObject;
                    elevateSlider.SetActive(false);
                    TranslateObjectControl();
                    RotateObjectControl();
                }
                else if ((arGameManager.currentPlaceableObject.name.Contains("SpaceshipAnimated")) || (arGameManager.currentPlaceableObject.name.Contains("PlanetRawSample"))){
                    // GameObject elevateSlider =  GameObject.FindObjectOfType<Slider>().gameObject;
                    GameObject elevateSlider = PlacementControllers.transform.Find("ElevateSlider").gameObject;
                    elevateSlider.SetActive(true);
                    ElevateObjectControl();
                    TranslateObjectControl();
                    RotateObjectControl();
                }
            }      
        // }
   
    }


    // ElevateObjectControl, TranslateObjectControl and RotateObjectControl method
    private void ElevateObjectControl()
    {
        GameObject elevateSlider =  GameObject.FindObjectOfType<Slider>().gameObject;
        Vector3 currentPosition = arGameManager.currentPlaceableObject.transform.localPosition;
        float currentSliderValue = (float)elevateSlider.GetComponent<Slider>().value;
        currentPosition.y = arGameManager.defaultHeight + arGameManager.defaultHeight * 2.0f * (currentSliderValue - 0.5f);
        arGameManager.currentPlaceableObject.transform.localPosition = currentPosition;
    }

    private void TranslateObjectControl()
    {       
        GameObject translateController = GameObject.FindGameObjectsWithTag("TranslateFixed Joystick")[0];
        // GameObject translateController = PlacementControllers.transform.Find("TranslateFixed Joystick");
        Vector3 currentPosition = arGameManager.currentPlaceableObject.transform.localPosition; 
        currentPosition.x += translateController.GetComponentInChildren<Joystick>().Horizontal * translateSpeed;
        currentPosition.z += translateController.GetComponentInChildren<Joystick>().Vertical * translateSpeed; 
        arGameManager.currentPlaceableObject.transform.localPosition = currentPosition;
    }

    private void RotateObjectControl()
    {
        GameObject rotateController = GameObject.FindGameObjectsWithTag("RotateFixed Joystick")[0];
        // GameObject rotateController = PlacementControllers.transform.Find("RotateFixed Joystick");
        // Vector3 currentRotation = arGameManager.currentPlaceableObject.transform.localRotation.eulerAngles;
        float horizontalValue = rotateController.GetComponentInChildren<Joystick>().Horizontal;
        float verticalValue = rotateController.GetComponentInChildren<Joystick>().Vertical; 
        float distanceFromCenter = Mathf.Sqrt(horizontalValue * horizontalValue + verticalValue * verticalValue);

        if (distanceFromCenter > 0.3)
        {
            angleAfterPassedThreshold = Mathf.Atan2(verticalValue, horizontalValue) * 180 / Mathf.PI;
            arGameManager.currentPlaceableObject.transform.localEulerAngles = objectAngleBeforePassedThreshold + new Vector3(0.0f , angleBeforePassedThreshold - angleAfterPassedThreshold, 0.0f);
            rotatingPassedThreshold = true;
        }
        else
        {
            objectAngleBeforePassedThreshold = arGameManager.currentPlaceableObject.transform.localEulerAngles;
            angleBeforePassedThreshold = Mathf.Atan2(verticalValue, horizontalValue) * 180 / Mathf.PI;
            rotatingPassedThreshold = false;
        }        
    }

}
