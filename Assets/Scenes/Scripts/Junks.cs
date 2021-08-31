using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // // ElevateObjectControl, TranslateObjectControl and RotateObjectControl method
    // private void ElevateObjectControl()
    // {
    //     GameObject elevateSlider =  PlacementControllers.transform.Find("ElevateSlider").gameObject;
    //     Vector3 currentPosition = arGameManager.currentPlaceableObject.transform.localPosition;
    //     float currentSliderValue = (float)elevateSlider.GetComponent<Slider>().value;
    //     currentPosition.y = defaultHeight + defaultHeight * 2.0f * (currentSliderValue - 0.5f);
    //     arGameManager.currentPlaceableObject.transform.localPosition = currentPosition;
    //     Debug.Log("ElevateObjectControl: " + currentPosition.ToString());
    // }


    // private void TranslateObjectControl()
    // {       
    //     GameObject translateController = PlacementControllers.transform.Find("TranslateFixed Joystick").gameObject;
    //     Vector3 currentPosition = arGameManager.currentPlaceableObject.transform.localPosition; 
    //     currentPosition.x += translateController.GetComponentInChildren<Joystick>().Horizontal * translateSpeed;
    //     currentPosition.z += translateController.GetComponentInChildren<Joystick>().Vertical * translateSpeed; 
    //     arGameManager.currentPlaceableObject.transform.localPosition = currentPosition;
    // }

    // private void RotateObjectControl()
    // {
    //     // Vector3 currentRotation = arGameManager.currentPlaceableObject.transform.localRotation.eulerAngles;
    //     GameObject rotateController = PlacementControllers.transform.Find("RotateFixed Joystick").gameObject;
    //     // Vector3 currentRotation = arGameManager.currentPlaceableObject.transform.localRotation.eulerAngles;
    //     float horizontalValue = rotateController.GetComponentInChildren<Joystick>().Horizontal;
    //     float verticalValue = rotateController.GetComponentInChildren<Joystick>().Vertical; 
    //     float distanceFromCenter = Mathf.Sqrt(horizontalValue * horizontalValue + verticalValue * verticalValue);

    //     Debug.Log(distanceFromCenter);

    //     if (distanceFromCenter > 0.5)
    //     {
    //         Vector3 currentRotation = new Vector3(0.0f , Mathf.Atan2(verticalValue, horizontalValue) * 180 / Mathf.PI, 0.0f);
    //         arGameManager.currentPlaceableObject.transform.localRotation = Quaternion.Euler(currentRotation);
    //     }
    // }



// public class PlacingObject : MonoBehaviour
// {
//     public GameObject placeableObjectPrefab;
//     private static GameObject currentPlaceableObject;
//     public GameObject PlacementControllers;
//     private float translateSpeed = 0.02f;
//     private float rotateSpeed = 0.002f;
//     private ARGameManager arGameManager; 

//     // Awake method
//     void Awake()
//     {
//         arGameManager = GameObject.FindObjectOfType<ARGameManager>();   
//     }

//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // If an object is being placed, read input to transform the object
//         if (currentPlaceableObject != null)
//         {
//             TranslateObjectControl();
//             RotateObjectControl();
//         }
//     }


//     // OnClick method
//     public void OnClick()
//     {

//         // Create or destroy new gameObject 
//         if (currentPlaceableObject == null){
//             currentPlaceableObject = Instantiate(placeableObjectPrefab);
//             currentPlaceableObject.transform.parent = arGameManager.planeAnchor.transform;
//             currentPlaceableObject.transform.localPosition = new Vector3(0.0f, 0.4f, 0.0f);
//             currentPlaceableObject.transform.localRotation = Quaternion.identity;
//         }
//         else
//         {
//             Destroy(currentPlaceableObject);
//         }
//     }

//     // TranslateObjectControl and RotateObjectControl method
//     private void TranslateObjectControl()
//     {       
//         GameObject translateController = PlacementControllers.transform.Find("TranslateFixed Joystick").gameObject;
//         Vector3 currentPosition = currentPlaceableObject.transform.localPosition; 
//         currentPosition.x += translateController.GetComponentInChildren<Joystick>().Horizontal * translateSpeed;
//         currentPosition.z += translateController.GetComponentInChildren<Joystick>().Vertical * translateSpeed; 
//         currentPlaceableObject.transform.localPosition = currentPosition;
//     }

//     private void RotateObjectControl()
//     {
//         // Vector3 currentRotation = currentPlaceableObject.transform.localRotation.eulerAngles;
//         GameObject rotateController = PlacementControllers.transform.Find("RotateFixed Joystick").gameObject;
//         // Vector3 currentRotation = currentPlaceableObject.transform.localRotation.eulerAngles;
//         float horizontalValue = rotateController.GetComponentInChildren<Joystick>().Horizontal;
//         float verticalValue = rotateController.GetComponentInChildren<Joystick>().Vertical; 
//         float distanceFromCenter = Mathf.Sqrt(horizontalValue * horizontalValue + verticalValue * verticalValue);

//         Debug.Log(distanceFromCenter);

//         if (distanceFromCenter > 0.5)
//         {
//             Vector3 currentRotation = new Vector3(0.0f , Mathf.Atan2(verticalValue, horizontalValue) * 180 / Mathf.PI, 0.0f);
//             currentPlaceableObject.transform.localRotation = Quaternion.Euler(currentRotation);
//         }
//     }

// }
        // // If an object is being placed, read input to transform the object
        // if (arGameManager.currentPlaceableObject != null)
        // {
        //     Debug.Log(arGameManager.currentPlaceableObject.name);

        //     // Only show Slider and run ElevateObjectControl if object is spaceship or planet
        //     if (arGameManager.currentPlaceableObject.name.Contains("GreenhouseRawSample")){
        //         GameObject elevateSlider =  PlacementControllers.transform.Find("ElevateSlider").gameObject;
        //         elevateSlider.SetActive(false);
        //         TranslateObjectControl();
        //         RotateObjectControl();
        //     }
        //     else if ((arGameManager.currentPlaceableObject.name.Contains("SpaceshipRawSample")) || (arGameManager.currentPlaceableObject.name.Contains("PlanetRawSample"))){
        //         GameObject elevateSlider =  PlacementControllers.transform.Find("ElevateSlider").gameObject;
        //         elevateSlider.SetActive(true);
        //         ElevateObjectControl();
        //         TranslateObjectControl();
        //         RotateObjectControl();
        //     }
        // }

    // public GameObject PlacementControllers;
    // private float translateSpeed = 0.02f;
    // private float rotateSpeed = 0.002f;            


}

            // // Check if there is touching
            // if (Input.touchCount>0)
            // {
            //     Debug.Log("Begin dragging 1!");
            //     Touch touch = Input.GetTouch(0);

            //     // Check phase of touch
            //     switch(touch.phase)
            //     {
            //         // If begin touching
            //         case TouchPhase.Began:
            //             Ray ray = Camera.main.ScreenPointToRay(touch.position);
            //             RaycastHit hit;
            //             if (Physics.Raycast(ray, out hit)){
            //                 // If hit cargo
            //                 if (GameObject.ReferenceEquals(transform.gameObject, hit.transform.gameObject)){
            //                     moveAllowed = true;
            //                     Debug.Log("Begin dragging 2!");
            //                 }
            //             }
            //             break;
            //     }
            // }

