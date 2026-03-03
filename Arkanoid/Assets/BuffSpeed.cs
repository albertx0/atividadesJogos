using UnityEngine;
using System.Collections;

public class BuffSpeedUp : MonoBehaviour
{
    public float speed = 3f;
    public float aumento = 1.5f;
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

            StartCoroutine(AumentarVelocidade(ball));

            Destroy(gameObject);
        }
    }

    IEnumerator AumentarVelocidade(Ball ball)
    {
        float velocidadeOriginal = ball.GetSpeed();

        ball.SetSpeed(velocidadeOriginal * aumento);

        yield return new WaitForSeconds(duracao);

        ball.SetSpeed(velocidadeOriginal);
    }
}