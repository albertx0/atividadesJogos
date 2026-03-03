using UnityEngine;

public class Bloco : MonoBehaviour
{
    public bool temBuff = false;
    public GameObject buffPrefab;

    public void DestroiBloco()
    {
        if (temBuff && buffPrefab != null)
        {
            Instantiate(buffPrefab, transform.position, Quaternion.identity);
        }
        // Avisa o GameManager que um bloco foi destruído
        FindFirstObjectByType<GameManager>().BlocoDestruido();

        Destroy(gameObject);
    }
}