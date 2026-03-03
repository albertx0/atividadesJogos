using UnityEngine;

public class BuffVida : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -8f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "naveMenor")
        {
            GameManager gm = FindFirstObjectByType<GameManager>();
            gm.ganharVida();

            Debug.Log("Vida extra!");

            Destroy(gameObject);
        }
    }
}