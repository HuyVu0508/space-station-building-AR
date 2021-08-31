using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject placeableObjectPrefab;
    public float defaultHeight;
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

        // Create or destroy new gameObject 
        if (arGameManager.currentPlaceableObject == null){
            arGameManager.currentPlaceableObject = Instantiate(placeableObjectPrefab);
            arGameManager.currentPlaceableObject.transform.parent = arGameManager.planeAnchor.transform;
            arGameManager.currentPlaceableObject.transform.localPosition = new Vector3(0.0f, defaultHeight, 0.0f);
            arGameManager.currentPlaceableObject.transform.localRotation = Quaternion.identity;
            arGameManager.currentPlaceableObject.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 90.0f, 0.0f));
            arGameManager.defaultHeight = defaultHeight;

            // GameObject PoppupTextSample = GameObject.Find("PoppupTextSample");
            // GameObject PoppupText = Instantiate(PoppupTextSample, arGameManager.currentPlaceableObject.transform.position, Quaternion.identity);
            // PoppupText.GetComponent<TextMesh>().text = "Object Created!";

        }
        else
        {
            Destroy(arGameManager.currentPlaceableObject);
        }
    }
}