using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    // Singleton pattern - only one instance of this class can exist
    public static UiManager instance;

    [Header("UI References")]
    public TextMeshProUGUI clickText;  // Text field to display total clicks
    public TextMeshProUGUI cpsText;    // Text field to display CPS

    private void Awake()
    {
        // Singleton setup
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateClicks(int clicks)
    {
        // Update the total click count
        clickText.text = clicks.ToString();
    }

    public void UpdateCPS(int cps)
    {
        // Update the CPS display
        cpsText.text = cps.ToString();
    }
}