using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Interactable : MonoBehaviour
{
    public GameObject interacter;
    public InteractionHandler handler;

    public virtual void Interact()
    { 
    }
}
