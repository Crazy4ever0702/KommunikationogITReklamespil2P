using UnityEngine;

public class DisappearOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
