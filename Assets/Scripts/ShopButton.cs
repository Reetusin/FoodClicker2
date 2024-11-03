using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopButton : MonoBehaviour
{

    public TextMeshProUGUI priceText;

    public TextMeshProUGUI countText;


    public void UpdateText(int price, int count)
    {
        priceText.text = $"price: {price}";
        countText.text = count.ToString();
    }
}
