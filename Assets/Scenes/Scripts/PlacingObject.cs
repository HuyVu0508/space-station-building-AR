using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacingObject : MonoBehaviour
{
    private ARGameManager arGameManager; 

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

    }

    // OnClick method
    public void OnClick()
    {
        // Reset currentPlaceableObject variable
        arGameManager.currentPlaceableObject = null;

        // Update NotificationText
        GameObject NotificationText = GameObject.Find("NotificationText");
        NotificationText.GetComponentInChildren<Text>().text = "Object Placed!";     
      
    }


}
