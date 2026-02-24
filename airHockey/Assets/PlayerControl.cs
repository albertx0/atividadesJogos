using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 pos;
    private float speed = 2.5f;
    private Rigidbody2D rb2d;
    

    public static float raio = 0.5f;

    public static float minX = -4.65f + raio;
    public static float maxX = 4.65f - raio;
    public static float minY = -7.6f + raio;
    public static float maxY = 0f - raio; // coisa para representar o meio do campo
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("aq");
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        pos = transform.position;
        
        pos.x = mousePos.x;
        pos.y = mousePos.y;

        // pegar limite esquerdo
        if(pos.x < minX) pos.x = minX;
        
        // pegar limite direito
        if(pos.x > maxX) pos.x = maxX;

         // pegar limite cima
        if(pos.y > maxY) pos.y = maxY;
        
        // pegar limite baixo
        if(pos.y < minY) pos.y = minY;
        

        transform.position = pos;
        
        Vector3 dir = mousePos - pos;
        dir.Normalize();

        Vector3 speedVec = dir * speed;
        
        var vel = rb2d.linearVelocity;
        
        vel.x = speedVec.x;
        vel.y = speedVec.y;

        rb2d.linearVelocity = vel; 

    }
}
