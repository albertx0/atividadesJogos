using UnityEngine;
using UnityEngine.SceneManagement;

public class InvaderGenerator : MonoBehaviour{
    public Invader[] prefabs;

    public int linhas;
    public int colunas;
    public int invaderMortos {get; private set;}
    public int totalInvaders => linhas * colunas;
    public int invaderVivos => this.totalInvaders - this.invaderMortos;

    public float espacamento = 2.3f;
    public float porcentagemMortos => 1.0f * this.invaderMortos / this.totalInvaders;
    public float freqDeAtaques = 100f;

    public Vector3 dir = Vector2.right;

    public AnimationCurve speed;

    public Projetar missel;

    public AudioSource barulhoMorte;
    public AudioSource barulhoTiro;

    private void Awake(){
        for(int i = 0; i < this.linhas; i++){
            // variaveis auxiliares para centralizar invasores
            float x = espacamento * (this.colunas - 1);
            float y = espacamento * (this.linhas - 1);

            Vector3 centro = new Vector3(-x/2.0f, -y/2.0f);

            // colocando espacamento vertical
            Vector3 posicaoLinha = new Vector3(centro.x, centro.y + i * espacamento, 0.0f);
            for(int j = 0; j < this.colunas; j++){
                Invader invader = Instantiate(this.prefabs[i], this.transform);

                invader.morreu += invaderMorreu;

                Vector3 posicao = posicaoLinha;

                // colocando espacamento horizontal
                posicao.x += j * espacamento;
                invader.transform.localPosition = posicao;
            }
        }
    }

    private void Start(){
        InvokeRepeating(nameof(ataqueInvader), this.freqDeAtaques, this.freqDeAtaques);
    }

    private void Update(){
        // atualizando posicao do invasor
        this.transform.position += this.dir * this.speed.Evaluate(porcentagemMortos) * Time.deltaTime;

        Vector3 paredeEsq = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 paredeDir = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach(Transform invader in this.transform){
            if(!invader.gameObject.activeInHierarchy){
                // significa que o carinha foi morto
                continue;
            }

            // verifica se eles estao indo para a direita e se alcancaram
            // o limite da tela
            if(dir == Vector3.right && invader.position.x >= paredeDir.x - 1.0f){
                avancarLinha();
            }

            if(dir == Vector3.left && invader.position.x <= paredeEsq.x + 1.0f){
                avancarLinha();
            }
        }
    }

    private void ataqueInvader(){
        foreach(Transform invader in this.transform){
            if(!invader.gameObject.activeInHierarchy){
                continue;
            }

            if(Random.value < (10.0f / (float)this.invaderVivos)){
                barulhoTiro.Play();
               Instantiate(this.missel, invader.position, Quaternion.identity);
               break;
            }
        }
    }

    private void avancarLinha(){
        dir *= -1.0f;

        Vector3 pos = transform.position;
        pos.y -= 1.0f;
        transform.position = pos;
    }

    private void invaderMorreu(){
        this.invaderMortos++;

        barulhoMorte.Play();

        if(this.invaderMortos >= this.totalInvaders){
            string nomeCenaAtual = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

            if (nomeCenaAtual == "fase1") UnityEngine.SceneManagement.SceneManager.LoadScene("fase2");
            if (nomeCenaAtual == "fase2") UnityEngine.SceneManagement.SceneManager.LoadScene("Cvitoria");
        }
    }
}
