using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public bool locked = true;

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
    private void OnCollisionEnter(Collision collision)
    {
        AcidScript _acid = collision.gameObject.GetComponent<AcidScript>();
        if (_acid != null)
        {
            locked = false;
        }
        GetComponent<BoxCollider>().enabled = false;
    }
}
