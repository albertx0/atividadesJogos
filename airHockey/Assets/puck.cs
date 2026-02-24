using UnityEngine;

public class Puck : MonoBehaviour
{
    public float speed = 18f;

    public float limitX = 6f;
    public float limitY = 9f;

    private AudioSource source;
    public AudioClip som;
    public AudioClip gol;


    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        vai();
    }

    void FixedUpdate()
    {
        if (rb2d.linearVelocity.magnitude > 0.01f)
        {
            rb2d.linearVelocity = rb2d.linearVelocity.normalized * speed;
        }

        if (Mathf.Abs(transform.position.x) > limitX ||
            Mathf.Abs(transform.position.y) > limitY)
        {
            voltar();
        }
    }

    //funcao quando o disco bate na parede
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("parede"))
        {
            source.PlayOneShot(som);

            Invoke(nameof(PararSom), 1.2f);
        }
    }


    //funcao quando sai gol
    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("gol"))
        {
            source.PlayOneShot(gol, 3f);

        }
    }*/

    void PararSom()
    {
        source.Stop();
    }

    void vai()
    {
        Vector2 dir = Random.insideUnitCircle.normalized;
        rb2d.linearVelocity = dir * speed;
    }

    void voltar()
    {
        transform.position = Vector3.zero;
        rb2d.linearVelocity = Vector2.zero;

        Invoke(nameof(vai), 0.5f);
    }
}


