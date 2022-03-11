using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void EnableKeyUI()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void DisableKeyUI()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void EnableCoinUI()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void DisableCoinUI()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public void EnableWinScreen()
    {
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void DisableWinScreen()
    {
        transform.GetChild(2).gameObject.SetActive(false);
    }
}
