using UnityEngine;

public class bunker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.layer == LayerMask.NameToLayer("Invader")){
            Destroy(this.gameObject);
        }
    }
}
