using UnityEngine;

public class TiroInimigo : MonoBehaviour
{
    public Projetar prefabLaserInimigo;
    public float intervaloTiro = 2f;
    private float cronometro;
    public AudioSource somTiro;

    void Start()
    {
        somTiro = GetComponent<AudioSource>();
    }

    void Update()
    {
        cronometro += Time.deltaTime;
        if (cronometro >= intervaloTiro)
        {
            Atirar();
            cronometro = 0;
        }
    }

    void Atirar()
    {
        if (somTiro != null) somTiro.Play();

        if (prefabLaserInimigo != null)
        {
            Projetar tiro = Instantiate(prefabLaserInimigo, transform.position, Quaternion.identity);
            tiro.dir = Vector3.left;
            tiro.speed = 10f;
        }
    }
}