using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int vidas = 3;
    public Ball ball;
    public TMP_Text vidasText;
    private int blocosRestantes;

    void Start()
    {
        AtualizarVida();

        // Conta quantos objetos têm a tag bloco
        blocosRestantes = GameObject.FindGameObjectsWithTag("bloco").Length;
    }

    public void BlocoDestruido()
    {
        blocosRestantes--;

        if (blocosRestantes <= 0)
        {
            ProximaFase();
        }
    }

    void ProximaFase()
    {
        string nomeCenaAtual = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (nomeCenaAtual == "Level1") UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
        else if (nomeCenaAtual == "Level2") UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
        else if (nomeCenaAtual == "Level3") UnityEngine.SceneManagement.SceneManager.LoadScene("Level4");
        else if (nomeCenaAtual == "Level4") UnityEngine.SceneManagement.SceneManager.LoadScene("Cvitoria");

    }

    public void perderVida()
    {
        vidas--;

        AtualizarVida();

        if (vidas <= 0)
        {
            GameOver();
        }
        else
        {
            Debug.Log(vidas);
            ball.reset();
        }
    }

    public void ganharVida()
    {
        vidas++;
        AtualizarVida();
    }

    void AtualizarVida()
    {
        vidasText.text = "VIDAS: " + vidas;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 1f;

        UnityEngine.SceneManagement.SceneManager.LoadScene("Cderrota");
    }
}