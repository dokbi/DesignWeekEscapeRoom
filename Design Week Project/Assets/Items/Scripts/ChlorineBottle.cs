using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChlorineBottle : MonoBehaviour, IUsable
{
    public void Use(ItemHandler _owner)
    {
        _owner.Drop();
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
