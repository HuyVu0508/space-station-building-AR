using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeAnchor : MonoBehaviour
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
        // Set self to arGameManager.planeAnchor to be used across objects
        arGameManager.planeAnchor = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        SetGravity();
    }

    // SetGravity method
    void SetGravity()
    {
        // Get gravity toward planeAnchor
        Vector3 normal = transform.TransformPoint(0,1,0) -  transform.TransformPoint(0,0,0);
        Physics.gravity = normal * (-9.8f); 
    }
    
}
