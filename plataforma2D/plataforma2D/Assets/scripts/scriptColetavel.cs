using UnityEngine;

public class FrangoColetavel : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.AddScore(value);
            }

            Destroy(gameObject);
        }
    }
}
