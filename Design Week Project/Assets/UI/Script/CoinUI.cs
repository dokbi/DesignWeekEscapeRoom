using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    private Text coinCount;

    private void Awake()
    {
        coinCount = transform.GetChild(1).GetComponent<Text>();
    }

    public void SetCoinCount(int _coinCount)
    {
        coinCount.text = _coinCount.ToString();
    }
}
