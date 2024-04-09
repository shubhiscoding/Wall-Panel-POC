using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Plane : MonoBehaviour
{
    public XRRayInteractor rayInteractorLeft; // Reference to the left hand ray interactor
    public XRRayInteractor rayInteractorRight; // Reference to the right hand ray interactor
    public GameObject plane2; // Reference to plane 2
    public GameObject Pannels; // Reference to the parent object of the planes
    public InputActionReference leftPointAction; // Input action for pointing with the left hand
    public InputActionReference rightPointAction; // Input action for pointing with the right hand

    private void Start()
    {
        leftPointAction.action.performed += OnLeftPointAction;
        rightPointAction.action.performed += OnRightPointAction;
    }

    private void Update()
    {
    }

    private void OnLeftPointAction(InputAction.CallbackContext context){
        // Perform a raycast
        RaycastHit hit;
        if (rayInteractorLeft.TryGetCurrent3DRaycastHit(out hit))
        {
            // Check if the ray hits plane 1
            if (hit.collider != null)
            {   Debug.Log("Hit");
                // Change the material of plane 2 to the material of plane 1
                GameObject plane1 = hit.collider.gameObject;
                GameObject parentObject = plane1.transform.parent.gameObject;
                Renderer renderer = plane2.GetComponent<Renderer>();
                if (renderer != null && plane1 != null && parentObject == Pannels)
                {
                    Bounds wallBounds = plane2.GetComponent<Renderer>().bounds;
                    Bounds panelBounds = plane1.GetComponent<Renderer>().bounds;

                    float tileX = wallBounds.size.x / panelBounds.size.x;
                    float tileY = wallBounds.size.y / panelBounds.size.y;

                    float spaceFactor = 0.95f; // Adjust this value to increase or decrease the space between tiles
                    tileX *= spaceFactor;
                    tileY *= spaceFactor;

                    renderer.material = plane1.GetComponent<Renderer>().material;
                    renderer.material.mainTextureScale = new Vector2(tileX, tileY);
                }
                else
                {
                    Debug.LogError("Select a plane a Pannel");
                }
            }else{
                Debug.Log("Miss");
            }
        }
    }
    private void OnRightPointAction(InputAction.CallbackContext context){
        // Perform a raycast
        RaycastHit hit;
        if (rayInteractorRight.TryGetCurrent3DRaycastHit(out hit))
        {
            // Check if the ray hits plane 1
            if (hit.collider != null)
            {   Debug.Log("Hit");
                // Change the material of plane 2 to the material of plane 1
                GameObject plane1 = hit.collider.gameObject;
                GameObject parentObject = plane1.transform.parent.gameObject;
                Renderer renderer = plane2.GetComponent<Renderer>();
                if (renderer != null && plane1 != null && parentObject == Pannels)
                {
                    Bounds wallBounds = plane2.GetComponent<Renderer>().bounds;
                    Bounds panelBounds = plane1.GetComponent<Renderer>().bounds;

                    float tileX = wallBounds.size.x / panelBounds.size.x;
                    float tileY = wallBounds.size.y / panelBounds.size.y;

                    float spaceFactor = 0.95f; // Adjust this value to increase or decrease the space between tiles
                    tileX *= spaceFactor;
                    tileY *= spaceFactor;

                    renderer.material = plane1.GetComponent<Renderer>().material;
                    renderer.material.mainTextureScale = new Vector2(tileX, tileY);
                }
                else
                {
                    Debug.LogError("Select a plane a Pannel");
                }
            }else{
                Debug.Log("Miss");
            }
        }
    }
}
