using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidScript : MonoBehaviour, IUsable
{

    public bool throwAcid = false;
    public GameObject acid;
    public GameObject thrower;
    void Update()
    {
        if (throwAcid == true)
        {
            throwAcid = false;
            Use();
            throwAcid = false;
        }
    }


    public void Use()
    {
        Instantiate(acid, thrower.transform.position, thrower.transform.rotation);
    }
}
