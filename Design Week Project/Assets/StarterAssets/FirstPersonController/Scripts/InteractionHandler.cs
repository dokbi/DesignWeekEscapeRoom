using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionHandler : MonoBehaviour
{
    public Interactable currentInteractable;
    private StarterAssetsInputs _input;

    private void Start()
    {
        _input.interact.AddListener(ProcessInteraction);
    }

    private void Update()
    {
        if ((transform.position - currentInteractable.transform.position).magnitude > 3f)
        {
            currentInteractable.handler = null;
            currentInteractable.interacter = null;
            currentInteractable = null;
        }
    }
    public void ProcessInteraction()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        currentInteractable = hit.collider.GetComponent<Interactable>();
        if (currentInteractable != null)
        {
            Debug.Log("Press E to Interact");
            currentInteractable.handler = this;
            currentInteractable.interacter = gameObject;
        }
    }
}
