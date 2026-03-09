using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int pontuacao = 0;
    public TMP_Text texto;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddPontos(int pontos)
    {
        pontuacao += pontos;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (texto != null)
            texto.text = "Pontuacao: " + pontuacao;
    }
}
