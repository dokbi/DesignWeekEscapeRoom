using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLevelData : MonoBehaviour
{
    public bool[] keys;
    public int coins;
    public int numberOfKeys = 5;
    public UnityEvent UpdateUI;

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
            Destroy(other.gameObject);
            UpdateUI.Invoke();
        }

        if (other.gameObject.GetComponent<Coin>() != null)
        {
            coins += other.gameObject.GetComponent<Coin>().value;
            Debug.Log("get key" + other.gameObject.GetComponent<Coin>().value);
            Destroy(other.gameObject);
            UpdateUI.Invoke();
        }
    }
}
