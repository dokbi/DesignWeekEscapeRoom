using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatSpin : MonoBehaviour
{
    public float floatDistance = -0.5f;
    private float y;

    void Start()
    {
        y = Random.Range(-1f, 1f);
    }

    void Update()
    {
        if (y >= 1)
        {
            y = -1;
        }
        y += Time.deltaTime;
        transform.Rotate(0, 15f * Time.deltaTime, 0);
        transform.Translate(floatDistance*Vector3.up * Mathf.Sin(y * Mathf.PI) * Time.deltaTime);
    }
}
