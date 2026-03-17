using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode atirarKey = KeyCode.Space;

    public float speed = 10.0f;
    public float boundY = 2.75f;
    private Rigidbody2D rb2d;

    public Projetar laser;
    public bool laserIsActive;
    public AudioSource barulhoTiro;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float velocidadeAtual = speed / Time.timeScale;

        var vel = rb2d.linearVelocity;
        if (Input.GetKey(moveUp)) vel.y = velocidadeAtual;
        else if (Input.GetKey(moveDown)) vel.y = -velocidadeAtual;
        else vel.y = 0;
        rb2d.linearVelocity = vel;

        var pos = transform.position;
        if (pos.y > boundY) pos.y = boundY;
        else if (pos.y < -boundY) pos.y = -boundY;
        transform.position = pos;

        if (Input.GetKeyDown(atirarKey)) Atirar();
    }

    private void Atirar()
    {
        if (!laserIsActive)
        {
            if (barulhoTiro != null) barulhoTiro.Play();
            Projetar projetil = Instantiate(this.laser, transform.position, Quaternion.identity);
            projetil.dir = Vector3.right;
            projetil.speed = 15f;
            projetil.bateu += LaserBateu;
            laserIsActive = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Jogador morre ao tocar em inimigos ou asteroides
        if (other.CompareTag("inimigo") || other.CompareTag("asteroide"))
        {
            Destroy(gameObject);
        }
    }

    private void LaserBateu()
    {
        laserIsActive = false;
    }
}