using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    public GameObject prefabInimigo; 
    public float tempoParaGerar = 2f; 
    private float cronometro;

    public float limiteY = 2.5f; 

    void Update()
    {
        cronometro += Time.deltaTime;

        if (cronometro >= tempoParaGerar)
        {
            GerarInimigo();
            cronometro = 0;
        }
    }

    void GerarInimigo()
    {
        
        float posicaoYAleatoria = Random.Range(-limiteY, limiteY);

        
        Vector3 posicaoSpawn = new Vector3(12f, posicaoYAleatoria, 0);

       
        Instantiate(prefabInimigo, posicaoSpawn, Quaternion.identity);
    }
}