using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public TextMeshProUGUI textoPontos;
    private int pontuacao = 0;

    // Variáveis para o Power Up de tempo
    private bool lentoAtivo = false;
    private float tempoNormalFixed;

    void Awake()
    {
        if (instancia == null) instancia = this;
    }

    void Start()
    {
        tempoNormalFixed = Time.fixedDeltaTime; 
        AtualizarInterface();
    }

    public void AdicionarPontos(int valor)
    {
        pontuacao += valor;
        AtualizarInterface();
    }

    void AtualizarInterface()
    {
        textoPontos.text = "Pontos: " + pontuacao;
        if(pontuacao >= 500){
            SceneManager.LoadScene("Vitoria");
        }
    }

    // Função para ativar o efeito vinda do Power Up
    public void AtivarCameraLenta(float duracao, float fator)
    {
        if (!lentoAtivo)
        {
            StartCoroutine(RotinaLento(duracao, fator));
        }
    }

    private System.Collections.IEnumerator RotinaLento(float duracao, float fator)
    {
        lentoAtivo = true;

        Time.timeScale = fator; 
        Time.fixedDeltaTime = tempoNormalFixed * fator; 

        yield return new WaitForSecondsRealtime(duracao);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = tempoNormalFixed;
        lentoAtivo = false;
    }
}