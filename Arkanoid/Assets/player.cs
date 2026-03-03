using UnityEngine;

public class player : MonoBehaviour
{
    // raio da nave
    private static float raio = 1.2f;

    // limites
    private float boundX = 5.0f - raio;

    private Rigidbody2D rb2d;

    public KeyCode moveDir = KeyCode.A;
    public KeyCode moveEsq = KeyCode.D;

    public float speed = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
        void Update () {

        var vel = rb2d.linearVelocity;               

        if (Input.GetKey(moveDir)) {             
            vel.x = -speed;
        }

        else if (Input.GetKey(moveEsq)) {      
            vel.x = speed;
        }
        else {
            vel.x = 0.0f;                          
        }

        rb2d.linearVelocity = vel;                  

        var pos = transform.position;           
        
        if(pos.x > boundX) pos.x = boundX;
        if(pos.x < -boundX) pos.x = -boundX;
        transform.position = pos;         
    }
}
