using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChlorineBottle : MonoBehaviour, IUsable
{
    public float lauchForce = 125f;
    private Rigidbody bottleRb;
    private void Awake()
    {
        bottleRb = GetComponent<Rigidbody>();
    }

    public void Use(ItemHandler _owner)
    {
        Vector3 facing = _owner.itemAnchor.transform.forward;
        _owner.Drop();
        bottleRb.AddForce(facing * lauchForce, ForceMode.Impulse);
        bottleRb.AddTorque(Vector3.right * lauchForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HydrogenBottle bottle = collision.gameObject.GetComponent<HydrogenBottle>();
        if (bottle != null)
        {
            Destroy(gameObject,0.1f);
        }
    }
}
