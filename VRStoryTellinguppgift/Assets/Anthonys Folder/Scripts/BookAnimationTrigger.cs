using UnityEngine;

public class BookAnimationTrigger: MonoBehaviour
{
    public Animator playerAnimator; // Reference to the Animator component of the player
    public string triggerName = "booktrigger"; // Name of the animation trigger

    // This method is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Trigger the animation
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger(triggerName);
            }
        }
    }
}
