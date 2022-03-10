using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLevelData : MonoBehaviour
{
    public bool[] keys;
    public int coins;
    public int numberOfKeys = 2;
    public UnityEvent<int> UpdateKey;
    public UnityEvent<int> UpdateCoin;
    private void Awake()
    {
        keys = new bool[numberOfKeys];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Key>() != null)
        {
            keys[other.gameObject.GetComponent<Key>().keyNumber] = true;
            Debug.Log("get key" + other.gameObject.GetComponent<Key>().keyNumber);
            UpdateKey.Invoke(other.gameObject.GetComponent<Key>().keyNumber);
            Destroy(other.gameObject);
        }

        if (other.gameObject.GetComponent<Coin>() != null)
        {
            coins += other.gameObject.GetComponent<Coin>().value;
            Debug.Log("get key" + other.gameObject.GetComponent<Coin>().value);
            UpdateCoin.Invoke(other.gameObject.GetComponent<Coin>().value);
            Destroy(other.gameObject);
        }
    }
}
