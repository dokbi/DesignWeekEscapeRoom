using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cogScript : MonoBehaviour
{
    public float rotationSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * 0.1f, 0, Space.Self);
    }
}
