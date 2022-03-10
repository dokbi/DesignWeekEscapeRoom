using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUI : MonoBehaviour
{
    private GameObject[] keys;

    // Start is called before the first frame update
    private void Awake()
    {
        keys = new GameObject[2];
        keys[0] = transform.GetChild(0).gameObject;
        keys[1] = transform.GetChild(1).gameObject;
        keys[2] = transform.GetChild(1).gameObject;
    }
    void Start()
    {
        keys[0].SetActive(false);
        keys[1].SetActive(false);
        keys[3].SetActive(false);
    }

    public void EnableKey(int keyNumber)
    {
        keys[keyNumber].SetActive(true);
    }
}
