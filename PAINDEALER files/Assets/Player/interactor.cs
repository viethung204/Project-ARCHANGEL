using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interactor : MonoBehaviour
{
    public LayerMask interactable;
    UnityEvent onInteract;
    private float interactRange = 2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit raycasthit;
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycasthit, interactRange, interactable))
            {
                if(raycasthit.collider.GetComponent<LightInteractable>() != null)
                {
                    onInteract = raycasthit.collider.GetComponent<LightInteractable>().onInteract;
                    onInteract.Invoke();
                }
            }
        }


    }
}
