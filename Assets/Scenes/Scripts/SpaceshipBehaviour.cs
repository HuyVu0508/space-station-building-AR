using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBehaviour : MonoBehaviour
{
    public GameObject cargoPrefab; 
    private float nextActionTime = 0.0f;
    public float interval = 5.0f;    
    private Vector3 pivot;
    public float speed = 0.5f;  
    public float zOffset = 3.0f;
    private Animator animatorComponent;
    private ARGameManager arGameManager; 

    // Awake method
    void Awake()
    {
        arGameManager = GameObject.FindObjectOfType<ARGameManager>();   
    }

    // Start is called before the first frame update
    void Start()
    {
        animatorComponent = transform.GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if in build mode or play mode
        if (arGameManager.GetMode() == "build_mode")
        {
            // Turn off animation
            animatorComponent.enabled = false;

            // Reset nextActionTime
            nextActionTime = 0.0f;
        }
        else if (arGameManager.GetMode() == "play_mode")
        {
            // Turn on animation
            animatorComponent.enabled = true;

            // Create cargo and drop it every interval
            dropCargo();
        }
    }

    // Drop cargo
    private void dropCargo()
    {
            if (Time.time > nextActionTime ) 
            {
                // Set up nextActionTime when first time in play mode
                if (nextActionTime==0){
                    nextActionTime = Time.time;
                }

                // Update time for next interval
                nextActionTime += interval;

                // Create cargo and drop
                GameObject newCargo = Instantiate(cargoPrefab);
                newCargo.transform.position = transform.position;

                // Set parent of cargo to planeAnchor
                newCargo.transform.parent = arGameManager.planeAnchor.transform;
            }
    }
}

