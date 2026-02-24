using UnityEngine;

public class inimigo : MonoBehaviour
{
    public Transform puck;
    public float speed = 1.5f;

    private Rigidbody2D rb2d;

    private float minX = -4.65f;
    private float maxX = 4.65f;
    private float minY = 0f;
    private float maxY = 7.6f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (puck == null) return;

        Vector2 target = rb2d.position;

        target.x = puck.position.x;
        target.y = puck.position.y;

        if(target.x < minX) target.x = minX;
        
        if(target.x > maxX) target.x = maxX;

        if(target.y < minY) target.y = minY;

        if(target.y > maxY) target.y = maxY;

        float smoothX = Mathf.Lerp(rb2d.position.x, target.x, 5f * Time.fixedDeltaTime);
        float smoothY = Mathf.Lerp(rb2d.position.y, target.y, 5f * Time.fixedDeltaTime);

        Vector2 newPos = new Vector2(smoothX, smoothY);

        rb2d.MovePosition(newPos);
    }

}

