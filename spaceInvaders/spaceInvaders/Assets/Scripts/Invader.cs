using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationsSprites;

    public float animationTime = 1.0f;

    private SpriteRenderer spriteRenderer;

    private int animationFrame;

    public int pontos;

    public System.Action morreu;

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start(){
        InvokeRepeating("AnimateSprite", this.animationTime, this.animationTime);
    }

    private void AnimateSprite(){
        animationFrame++;

        if(animationFrame >= this.animationsSprites.Length){
            animationFrame = 0;
        }

        spriteRenderer.sprite = this.animationsSprites[animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Laser")){
            ScoreManager.Instance.AddPontos(pontos);
            this.morreu.Invoke();
            this.gameObject.SetActive(false);
        }
     }
}
