using UnityEngine;

public class MotherShip : MonoBehaviour
{
    public float speed = 5f;
    public float limiteEsquerda = -10f;
    public float limiteDireita = 10f;

    public int pontos = 50;

    private Vector3 direction = Vector3.right;

    void Start()
    {
        // começa indo para a direita
        direction = Vector3.right;

        // ajuste a posição inicial se necessário
        transform.position = new Vector3(limiteEsquerda, transform.position.y, 0);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        // inverte direção ao chegar nos limites
        if (transform.position.x >= limiteDireita)
        {
            direction = Vector3.left;
            transform.position = new Vector3(limiteDireita, transform.position.y, 0);
        }
        else if (transform.position.x <= limiteEsquerda)
        {
            direction = Vector3.right;
            transform.position = new Vector3(limiteEsquerda, transform.position.y, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddPontos(pontos);
            Destroy(gameObject);
        }
    }
}
