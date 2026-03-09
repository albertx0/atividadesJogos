using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Projetar laser;

    public float speed = 6.0f;

    public bool laserIsActive;

    public int vidas;

    public AudioSource barulhoTiro;

    private void Update(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.position += Vector3.left * this.speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.RightArrow)){
            transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.Space)){
            atirar();
        }
    }

    private void atirar(){
        if(!laserIsActive){
            barulhoTiro.Play();
            Projetar projetil = Instantiate(this.laser, transform.position, Quaternion.identity);
            projetil.bateu += laserBateu;
            laserIsActive = true;
        }
    }

    private void laserBateu(){
        laserIsActive = false;
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        // caso foi com um missel
        if(colisao.gameObject.layer == LayerMask.NameToLayer("Missile")){
            VidaManager.Instance.UpdateVidasUI(--vidas);
        }

        // se foi o invader, ja era mesmo tendo vidas sobrando e verifica se tem vidas sobrando
        if(vidas < 1 || colisao.gameObject.layer == LayerMask.NameToLayer("Invader")){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Cderrota");
            Debug.Log("Morreu");
        }
    }
}
