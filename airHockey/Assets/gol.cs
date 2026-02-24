using UnityEngine;

public class gol : MonoBehaviour
{   
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.tag == "disco")
        {
            string wallName = transform.name;
            placar.score(wallName);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
