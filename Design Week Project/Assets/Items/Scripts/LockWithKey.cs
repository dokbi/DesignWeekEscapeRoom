using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockWithKey : Interactable
{
    public bool locked = true;
    public int keyNumber = 0;

    private GameObject lockBody;
    private GameObject lockShackle;
    private void Awake()
    {
        lockBody = transform.GetChild(0).GetChild(0).gameObject;
        lockShackle = transform.GetChild(1).GetChild(0).gameObject;
    }
    private void Update()
    {
        if (!locked)
        {
            lockBody.GetComponent<Rigidbody>().isKinematic = false;
            lockShackle.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public override void Interact()
    {
        if (interacter.GetComponent<PlayerLevelData>().keys[keyNumber])
        {
            locked = false;
        }
        else
        {
            Debug.Log("you don't have the key");
        }
    }
}
