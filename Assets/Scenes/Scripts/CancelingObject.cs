using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelingObject : MonoBehaviour
{

    private ARGameManager arGameManager; 

    // Awake method
    void Awake()
    {
        arGameManager = GameObject.FindObjectOfType<ARGameManager>();   
    }

    // OnClick method
    public void OnClick()
    {
        // Canceling creating object
        Destroy(arGameManager.currentPlaceableObject);

        // Update NotificationText
        GameObject NotificationText = GameObject.Find("NotificationText");
        NotificationText.GetComponentInChildren<Text>().text = "Object Canceled!";           
    }


}
