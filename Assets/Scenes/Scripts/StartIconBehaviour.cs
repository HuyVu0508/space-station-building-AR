using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIconBehaviour : MonoBehaviour
{

    public float rotateSpeedSelf = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate around object's center
        transform.Rotate(rotateSpeedSelf * (new Vector3(0.0f, 0.0f, 1.0f)));        
    }
}
