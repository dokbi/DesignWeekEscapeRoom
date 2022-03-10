using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Interactable : MonoBehaviour
{
    public delegate void InteractionFunction();
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<InteractionHandler>().currentInteractable = this;
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<InteractionHandler>().currentInteractable = null;
    }
}
