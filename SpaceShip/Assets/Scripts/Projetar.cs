using UnityEngine;

public class Projetar : MonoBehaviour
{
    public Vector3 dir;
    public float speed;
    public System.Action bateu;

    void Start()
    {

        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        // Move o laser baseado na direção e velocidade recebidas
        transform.position += this.dir * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (this.bateu != null) { 
            this.bateu.Invoke(); 
        }
        Destroy(this.gameObject);
    }

    // Garante que o jogador possa atirar novamente se o laser sumir por tempo
    private void OnDestroy()
    {

        if (this.bateu != null)
            this.bateu.Invoke();
    }
}