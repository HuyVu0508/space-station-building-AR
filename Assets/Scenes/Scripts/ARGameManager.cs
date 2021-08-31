using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARGameManager : MonoBehaviour
{
    private string gameMode = "build_mode";
    [HideInInspector]
    public GameObject planeAnchor;
    [HideInInspector]
    public GameObject currentPlaceableObject;
    [HideInInspector]
    public float defaultHeight;
    [HideInInspector]
    public string dayNight = "day";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // GetMode mothod
    public string GetMode()
    {
        return gameMode;
    }

    // SwitchMode method
    public void SwitchMode()
    {
        if (gameMode == "build_mode")
        {
            gameMode = "play_mode";
            SetUpPlayMode();
        }
        else if (gameMode == "play_mode") 
        {
            gameMode = "build_mode";
            SetUpBuildMode();
        }
    }

    // Set up Build mode and Play mode
    void SetUpBuildMode()
    {
        // Find gameObjects to be changed
        GameObject NotificationText = GameObject.Find("NotificationText");
        GameObject SwitchModeButton = GameObject.Find("SwitchModeButton");
        GameObject PlacementControllers = GameObject.FindObjectOfType<Canvas>().transform.Find("PlacementControllers").gameObject;
        

        // Change gameObjects
        NotificationText.GetComponentInChildren<Text>().text = "Now in Build Mode";
        SwitchModeButton.GetComponentInChildren<Text>().text = "Switch to Play Mode";
        PlacementControllers.SetActive(true);

    }

    void SetUpPlayMode()
    {
        // Find gameObjects to be changed
        GameObject NotificationText = GameObject.Find("NotificationText");
        GameObject SwitchModeButton = GameObject.Find("SwitchModeButton");
        GameObject startIcon = GameObject.Find("StartIcon");        
        GameObject PlacementControllers = GameObject.FindObjectOfType<Canvas>().transform.Find("PlacementControllers").gameObject;


        // Change gameObjects
        NotificationText.GetComponentInChildren<Text>().text = "Now in Play Mode";
        SwitchModeButton.GetComponentInChildren<Text>().text = "Switch to Build Mode";
        PlacementControllers.SetActive(false);
        startIcon.SetActive(false);
    }    

}
