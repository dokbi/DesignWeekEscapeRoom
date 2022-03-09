using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidProjectileScript : MonoBehaviour
{
    Rigidbody rb;
    public float throwPower = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
