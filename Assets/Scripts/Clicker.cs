using UnityEngine;
using DG.Tweening;

public class Clicker : MonoBehaviour
{
    [Header("Animation")]
    public float scale = 1.2f;
    public float duration = 0.5f;
    public Ease ease = Ease.OutElastic;

    [Header("Audio")]
    public AudioClip clickSound;

    [Header("VFX")]
    public ParticleSystem clickVFX;

    [HideInInspector] public int clicks = 0; // Total clicks
    private AudioSource audioSource;

    private float timeSinceLastClick = 0f; // Timer to track time for CPS calculation
    private int clicksInLastSecond = 0; // Clicks in the last second (for CPS)

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Track time to calculate CPS
        timeSinceLastClick += Time.deltaTime;

        // Once a second has passed, update CPS and reset
        if (timeSinceLastClick >= 1f)
        {
            UiManager.instance.UpdateCPS(clicksInLastSecond);
            clicksInLastSecond = 0;
            timeSinceLastClick = 0f;
        }
    }

    private void OnMouseDown()
    {
        // Increment the click count
        clicks++;
        clicksInLastSecond++; // Increment the clicks for CPS calculation

        // Update the click count UI
        UiManager.instance.UpdateClicks(clicks);

        // Play VFX and sound
        clickVFX.Emit(1);
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(clickSound);

        // Animate the clicker object
        transform
            .DOScale(1, duration)
            .ChangeStartValue(scale * Vector3.one)
            .SetEase(ease);
    }
}
