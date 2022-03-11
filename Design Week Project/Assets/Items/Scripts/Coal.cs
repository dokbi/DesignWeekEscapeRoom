using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coal : MonoBehaviour, IUsable
{
    public float lauchForce = 125f;
    private Rigidbody Rb;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    public void Use(ItemHandler _owner)
    {
        Vector3 facing = _owner.itemAnchor.transform.forward;
        _owner.Drop();
        Rb.AddForce(facing * lauchForce, ForceMode.Impulse);
        Rb.AddTorque(Vector3.right * lauchForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        WinCondition gauldron = collision.gameObject.GetComponent<WinCondition>();
        if (gauldron != null)
        {
            Destroy(gameObject);
        }
    }
}
