using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    public float rotateSpeedSelf = 0.1f;
    public float rotateSpeedPlane = 0.1f;
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
        // Check if in build mode or play mode
        if (arGameManager.GetMode() == "build_mode")
        {
            Debug.Log("transform.localPosition: " + transform.localPosition.ToString());
        }
        else if (arGameManager.GetMode() == "play_mode")
        {
            // Rotate around object's center
            transform.Rotate(rotateSpeedSelf * Vector3.up);
            // Rotate around plane's origin
            Vector3 pivot = transform.parent.TransformPoint(new Vector3(0.0f, transform.localPosition.y, 0.0f));
            transform.RotateAround(pivot, transform.parent.TransformDirection(new Vector3(0.0f, 1.0f, 0.0f)), Time.deltaTime * rotateSpeedPlane);
            Debug.Log("pivot: " + pivot.ToString());
            Debug.Log("Vector3.up: " + Vector3.up.ToString());

        }
    }
}