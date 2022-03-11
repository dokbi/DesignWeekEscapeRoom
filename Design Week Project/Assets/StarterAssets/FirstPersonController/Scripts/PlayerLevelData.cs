using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLevelData : MonoBehaviour
{
    private bool[] keys;
    private int coins;
    public UnityEvent<int> UpdateKey;
    public UnityEvent<int> UpdateCoin;
    private void Awake()
    {
        keys = new bool[3];
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
            Debug.Log("get coin" + other.gameObject.GetComponent<Coin>().value);
            UpdateCoin.Invoke(coins);
            Destroy(other.gameObject);
        }
    }
}
