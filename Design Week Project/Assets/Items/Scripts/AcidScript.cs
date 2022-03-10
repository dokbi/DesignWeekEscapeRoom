using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidScript : MonoBehaviour, IUsable
{
    public float lauchForce;
    private Rigidbody acidRb;
    private bool armed;
    private void Awake()
    {
        acidRb = GetComponent<Rigidbody>();
    }

    public void Use(ItemHandler _owner)
    {
        Vector3 facing = _owner.itemAnchor.transform.forward;
        _owner.Drop();
        acidRb.AddForce(facing * lauchForce,ForceMode.Impulse);
        acidRb.AddTorque(Vector3.right * lauchForce, ForceMode.Impulse);
        armed = true;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (armed)
    //    {
    //        Lock _lock = collision.gameObject.GetComponent<Lock>();
    //        if (_lock != null)
    //        {
    //            _lock.locked = false;
    //        }
    //        Destroy(gameObject);
    //    }
    //}
}
