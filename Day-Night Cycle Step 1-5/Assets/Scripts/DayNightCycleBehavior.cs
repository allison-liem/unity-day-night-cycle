using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightCycleBehavior : MonoBehaviour
{
    // How long is the day?
    public float dayLength = 10.0f;
    // How long is the night?
    public float nightLength = 10.0f;

    // What color should be day light be?
    public Color dayColor = new Color(1.0f, 1.0f, 1.0f);
    // What color should the night light be?
    public Color nightColor = new Color(0.25f, 0.25f, 0.6f);

    // Reference to the global light
    private Light2D light2D;

    // Is it day or night currently?
    public bool daytime { get; private set; }
    // How long more does the current day/night last?
    private float timeRemaining;

    void Start()
    {
        light2D = GetComponent<Light2D>();

        daytime = true;
        timeRemaining = dayLength;
        light2D.color = dayColor;
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        // Is it time to switch day and night?
        if (timeRemaining <= 0)
        {
            // Day becomes night, night becomes day
            daytime = !daytime;
            // Update the global light's color, and reset timeRemaining
            if (daytime)
            {
                light2D.color = dayColor;
                timeRemaining = dayLength;
            } else
            {
                light2D.color = nightColor;
                timeRemaining = nightLength;
            }
        }
    }
}
