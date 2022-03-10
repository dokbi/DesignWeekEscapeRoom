using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public bool locked = true;

    private Renderer lockRenderer;
    private void Awake()
    {
        lockRenderer = transform.GetChild(0).GetComponent<Renderer>();
    }
    private void Update()
    {
        if (!locked)
        {
            lockRenderer.material.color = Color.Lerp(lockRenderer.material.color, Color.clear, 1.5f * Time.deltaTime);
        }
    }
}
