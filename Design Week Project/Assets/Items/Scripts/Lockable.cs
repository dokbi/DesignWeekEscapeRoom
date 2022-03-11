using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockable : MonoBehaviour
{
    private Lock _lock;
    private Renderer _renderer;
    private BoxCollider _boxCollider;
    void Start()
    {
        _lock = transform.GetChild(0).GetComponent<Lock>();
        _renderer = GetComponent<Renderer>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_lock.locked)
        {
            _boxCollider.enabled = false;
            _renderer.material.color = Color.Lerp(_renderer.material.color, Color.clear, 1.5f * Time.deltaTime);
        }
    }
}
