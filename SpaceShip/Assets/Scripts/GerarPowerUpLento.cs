using UnityEngine;

public class GeradorPowerUp : MonoBehaviour
{
    public GameObject prefabPowerUp;
    public float tempoParaGerar = 15f;
    private float cronometro;
    public float limiteY = 2.5f;

    void Update()
    {
        cronometro += Time.deltaTime;

        if (cronometro >= tempoParaGerar)
        {
            GerarBuff();
            cronometro = 0;
        }
    }

    void GerarBuff()
    {
        float posY = Random.Range(-limiteY, limiteY);
        Vector3 posicaoSpawn = new Vector3(12f, posY, 0);
        Instantiate(prefabPowerUp, posicaoSpawn, Quaternion.identity);
    }
}