using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    // 默认金币
    public uint defaultCoinQuantity;

    // UI
    public TextMeshProUGUI coinQuantityUI;

    // 当前金币
    private static uint _currentCoinQuantity;
    // Start is called before the first frame update
    void Start()
    {
        _currentCoinQuantity = defaultCoinQuantity;
        coinQuantityUI.text = _currentCoinQuantity.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InsertCoinQuantity(uint val)
    {
        _currentCoinQuantity += val;
        coinQuantityUI.text = _currentCoinQuantity.ToString();
    }
}
