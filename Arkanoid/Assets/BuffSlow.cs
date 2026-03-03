using UnityEngine;
using System.Collections;

public class BuffSlow : MonoBehaviour
{
    public float speed = 3f;
    public float reducao = 0.5f;
    public float duracao = 5f;

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
            Ball ball = FindFirstObjectByType<Ball>();

            StartCoroutine(DiminuirVelocidade(ball));

            Destroy(gameObject);
        }
    }

    IEnumerator DiminuirVelocidade(Ball ball)
    {
        float velocidadeOriginal = ball.GetSpeed();

        ball.SetSpeed(velocidadeOriginal * reducao);

        yield return new WaitForSeconds(duracao);

        ball.SetSpeed(velocidadeOriginal);
    }
}