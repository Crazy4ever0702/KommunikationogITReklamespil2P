using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Egg"))
        {
            GameManager.Instance.AddEgg(1);
            Destroy(other.gameObject); // remove egg
        }
        else if (other.CompareTag("Bomb"))
        {
            GameManager.Instance.HitBomb();
            Destroy(other.gameObject); // optional: remove bomb
        }
    }
}