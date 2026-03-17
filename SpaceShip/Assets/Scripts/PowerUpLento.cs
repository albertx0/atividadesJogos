using UnityEngine;

public class PowerUpLento : MonoBehaviour
{
    public float velocidade = 3f; 
    public float duracao = 5f;   
    public float fatorLento = 0.5f; 

    void Update()
    {
        transform.position += Vector3.left * velocidade * Time.deltaTime;

   
        if (transform.position.x < -12f) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            if (GameManager.instancia != null)
            {
                GameManager.instancia.AtivarCameraLenta(duracao, fatorLento);
            }
            Destroy(gameObject); 
        }
    }
}