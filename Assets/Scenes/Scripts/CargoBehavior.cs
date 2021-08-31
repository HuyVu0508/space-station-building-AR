using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargoBehaviou : MonoBehaviour
{
    private bool moveAllowed;
    private ARGameManager arGameManager; 
    private GameObject groundPlane;

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

        }
        else if (arGameManager.GetMode() == "play_mode")
        {

            // Check if there is touching
            if (Input.GetMouseButton(0))
            {

                // Check phase of touch
                if (Input.GetMouseButtonDown(0)){
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit)){
                        // If hit cargo
                        if (GameObject.ReferenceEquals(transform.gameObject, hit.transform.gameObject)){
                            moveAllowed = true;
                        }
                    }
                }
                else
                {
                    // If cargo is being dragged
                    if (moveAllowed == true){
                        
                        // Get position of ray's hit on ground plane
                        int layerMask = 1 << 8;
                        
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        // If hit ground
                        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)){

                            // Get the groundPlane object
                            groundPlane = hit.transform.gameObject;

                            // Get hit point's position relative to ground plane
                            Vector3 hitPointWorldPosition = hit.point;
                            Vector3 hitPointLocalPosition = groundPlane.transform.InverseTransformPoint(hitPointWorldPosition);

                            // Set cargo's position to hitPointLocalPosition
                            Vector3 currentLocalPosition = transform.localPosition;
                            Vector3 originalCurrentLocalPosition = transform.localPosition;
                            currentLocalPosition.x = hitPointLocalPosition.x;
                            currentLocalPosition.z = hitPointLocalPosition.z;
                            transform.localPosition = currentLocalPosition;

                        }
                    }
                }
            }
            else if (Input.GetMouseButtonUp(0)){

                    // Not allow moving anymore
                    if (moveAllowed == true){
                        moveAllowed = false;
                    }

                    // Check if cargo enters any greenshouse
                    EnterGreenhouse();
                }

        }       
    }

    // Method checking if cargo enters greenhouse and steps
    private void EnterGreenhouse(){

        // Find all greenhouses 
        GameObject [] greenhouses = GameObject.FindGameObjectsWithTag("Greenhouse");

        // Loop through all greenhouses
        if (greenhouses.Length > 0){
            foreach (GameObject greenhouse in greenhouses)
            {
                if (CheckEnterGreenhouse(transform.gameObject, greenhouse)){

                    GameObject PoppupTextSample = GameObject.FindGameObjectsWithTag("Poppup Text Sample")[0];
                    GameObject PoppupText = Instantiate(PoppupTextSample, transform.position, Quaternion.identity);
                    PoppupText.GetComponent<TextMesh>().text = "Cargo Retrieved!";
                    Destroy(PoppupText, 3.0f);

                    Destroy(transform.gameObject);
                }
            }            
        }
    

    }

    //  Method checking if cargo enters greenshouse
    private bool CheckEnterGreenhouse(GameObject cargo, GameObject greenhouse){
        Vector3 position1 =  cargo.transform.position;
        Vector3 position2 =  greenhouse.transform.position;
        Vector3 areaSize = greenhouse.transform.GetComponent<Collider>().bounds.size;

        float x_distance = Mathf.Abs(position1.x - position2.x);
        float z_distance = Mathf.Abs(position1.z - position2.z);

        if ( (x_distance < (areaSize.x/2)) && (z_distance < (areaSize.z/2)) ){
            return true;
        }
        else{
            return false;
        }
    }         
}
