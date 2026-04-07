using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerController player = col.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.Die();
            }
        }
    }
}
