using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidScript : MonoBehaviour, IUsable
{
    public float lauchForce;
    private Rigidbody acidRb;
    private bool armed;
    private bool destoryed;
    private Renderer bottleRenderer;
    private void Awake()
    {
        acidRb = GetComponent<Rigidbody>();
        bottleRenderer = transform.GetChild(0).GetComponent<Renderer>();
    }

    private void Update()
    {
        if (destoryed)
        {
            bottleRenderer.material.color = Color.Lerp(bottleRenderer.material.color, Color.clear, 3f * Time.deltaTime);
        }
    }

    public void Use(ItemHandler _owner)
    {
        Vector3 facing = _owner.itemAnchor.transform.forward;
        _owner.Drop();
        acidRb.AddForce(facing * lauchForce, ForceMode.Impulse);
        acidRb.AddTorque(Vector3.right * lauchForce, ForceMode.Impulse);
        armed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (armed)
        {
            Destroy(gameObject,1f);
            destoryed = true;
        }
    }
}
