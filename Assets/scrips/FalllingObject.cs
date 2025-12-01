using UnityEngine;
public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 5f;
    public float bottomY = -5f;

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);
        }
    }
}