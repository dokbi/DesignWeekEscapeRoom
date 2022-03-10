using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrogenBottle : MonoBehaviour, IUsable
{
    public GameObject acidBottle;
    public void Use(ItemHandler _owner)
    {
        _owner.Drop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ChlorineBottle bottle = collision.gameObject.GetComponent<ChlorineBottle>();
        if (bottle!=null)
        {
            Instantiate(acidBottle, bottle.transform.position,bottle.transform.rotation);
            Destroy(gameObject);
        }
    }
}
