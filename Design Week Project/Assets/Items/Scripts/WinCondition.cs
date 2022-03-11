using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinCondition : MonoBehaviour
{
    public UnityEvent victory;
    private Coal coal;
    private void OnCollisionEnter(Collision collision)
    {
        coal = collision.gameObject.GetComponent<Coal>();
        if (coal != null)
        {
            victory.Invoke();
        }
    }
}
