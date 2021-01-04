using UnityEngine;

public class WolfBehavior : MonoBehaviour
{
    private Animator animator;
    private DayNightCycleBehavior dayNightCycle;

    void Start()
    {
        animator = GetComponent<Animator>();
        dayNightCycle = FindObjectOfType<DayNightCycleBehavior>();
    }

    void Update()
    {
        // Sleep when it's day time, dance through the night
        animator.SetBool("Sleep", dayNightCycle.daytime);
    }
}
