using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // referencia: https://github.com/chrisgodfrey/Arkanoid/blob/master/Assets/Scripts/Ball.cs

    public float speed = 100.0f;
    public GameObject playerObject;
    public bool ballActive;
    public Vector3 ballPosition;
    //public GameObject GameManager;
    public AudioClip hitVaus;
    public AudioClip hitBrick;
    private float LeftWallHitY;
    private float RightWallHitY;
    private Rigidbody2D rb2d;
    public GameManager gm;

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        // x                    <- origin point of racket sprite
        return (ballPos.x - (racketPos.x + (racketWidth / 2))) / racketWidth;
    }

    // inicializa a bola
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("bola").GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // caso bater na nave
        if (col.gameObject.name == "naveMenor")
        {
            //GetComponent<AudioSource>().PlayOneShot(hitVaus, 1);

            // de acordo de onde bate vai ter uma dir
            float x = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, 1).normalized;

            GetComponent<Rigidbody2D>().linearVelocity = dir * speed;
        }

        // evitando loopings chatos
        if (col.gameObject.tag == "paredeEsq")
        {
            LeftWallHitY = gameObject.transform.position.y;
        }

        if (col.gameObject.tag == "paredeDir")
        {
            RightWallHitY = gameObject.transform.position.y;
        }

        if (ballActive == true && LeftWallHitY != 0 && LeftWallHitY == RightWallHitY)
        {
            // dir inicial
            Vector2 dir = new Vector2(50, 100).normalized;
            rb2d.linearVelocity = dir * speed;
        }

        //destruir blocos
        if (col.gameObject.tag == "bloco")
        {
            Bloco bloco = col.gameObject.GetComponent<Bloco>();

            if (bloco != null)
            {
                bloco.DestroiBloco();
            }
            else
            {
                Destroy(col.gameObject);
            }
        }
    }

    void Update()
    {
        // esperando o jogador apertar espaco
        if (Input.GetKeyDown("space"))
        {
            if (ballActive == false)
            {
                Vector2 dir = new Vector2(50, 100).normalized;

                rb2d.linearVelocity = dir * speed;

                ballActive = true;

                //etComponent<AudioSource>().PlayOneShot(hitVaus, 1);
            }
        }

        if (ballActive == false && playerObject != null)
        {
            // usando a posicao do jogador
            ballPosition.x = (playerObject.transform.position.x + 20);
            ballPosition.y = (playerObject.transform.position.y + 12);

            // aplica a posicao do jogado como ref para a bola
            GetComponent<Rigidbody2D>().transform.position = ballPosition;
        }

        if (transform.position.y < -8.5)
        {
            ballActive = false;
            gm.perderVida();
        }

        // caso a bola caia
        //if (GetComponent<Rigidbody2D>().transform.position.y < 0)
        //  {
        // was that the last ball in play?
        //   if (GameObject.FindGameObjectsWithTag("Ball").Length == 1)
        //    {
        //       ballActive = false;
        // call the 'lose life' function in game manager script
        //       GameManager.GetComponent<GameManager>().LoseLife();
        //    }
        //    else
        //   {
        // destroy this ball as there's at least 1 left in play
        //       Destroy(gameObject);
        // }
        // }
    }

    public void reset()
    {
        ballActive = false;

        rb2d.linearVelocity = Vector2.zero;

        transform.position = new Vector3(0, -3, 0);
    }

    // função usada pelos buffs para alterar a velocidade da bola
    // ela também atualiza a velocidade atual do Rigidbody
    // mantendo a direção da bola, apenas mudando a intensidade
    public void SetSpeed(float novaSpeed)
    {
        speed = novaSpeed;

        if (ballActive)
        {
            rb2d.linearVelocity = rb2d.linearVelocity.normalized * speed;
        }
    }

    // retorna a velocidade atual da bola
    // os buffs usam essa função para salvar a velocidade original
    // antes de modificar temporariamente
    public float GetSpeed()
    {
        return speed;
    }
}