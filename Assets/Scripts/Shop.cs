using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Chef")]
    public ShopButton chefButton;
    public int chefPrice = 10;
    public int chefCount = 0;

    private Clicker clicker;
    private Coroutine chefCoroutine;

    private void Start()
    {
        clicker = FindObjectOfType<Clicker>();
        chefButton.UpdateText(chefPrice, chefCount);
    }

    public void BuyChef()
    {
        if (clicker.clicks >= chefPrice)
        {
            clicker.clicks -= chefPrice;
            UiManager.instance.UpdateClicks(clicker.clicks);

            chefCount++;
            chefPrice = Mathf.RoundToInt(chefPrice * 1.5f); // Increase price by 15%
            chefButton.UpdateText(chefPrice, chefCount);

 
            if (chefCoroutine == null)
            {
                chefCoroutine = StartCoroutine(IncreaseClicksOverTime());
            }
        }
    }

    private IEnumerator IncreaseClicksOverTime()
    {
        while (true) 
        {
            clicker.clicks += chefCount; 
            UiManager.instance.UpdateClicks(clicker.clicks); 
            yield return new WaitForSeconds(1f); 
        }
    }
}
