using UnityEngine;

public class Projetar : MonoBehaviour
{
    public Vector3 dir;

    public float speed;

    public System.Action bateu;

    private void Update(){
        transform.position += this.dir * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(this.bateu != null)
            this.bateu.Invoke();
        Destroy(this.gameObject);
    }
}
