using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        transform.position += Vector3.left * velocidade * Time.deltaTime;
        if (transform.position.x < -12f) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se for atingido pelo laser do jogador
        if (other.CompareTag("Laser"))
        {
            if (GameManager.instancia != null)
            {
                // Verifica a TAG deste objeto (o asteroide ou o inimigo)
                if (gameObject.CompareTag("inimigo"))
                {
                    GameManager.instancia.AdicionarPontos(50);
                }
                else if (gameObject.CompareTag("asteroide"))
                {
                    GameManager.instancia.AdicionarPontos(10);
                }
            }
            Destroy(gameObject);
        }

        // Se bater no jogador
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); 
            Destroy(gameObject);
            SceneManager.LoadScene("Derrota");
        }
    }
}