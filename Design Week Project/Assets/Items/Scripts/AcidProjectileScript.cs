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
        rb.AddForce(transform.forward * throwPower, ForceMode.Impulse);
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
