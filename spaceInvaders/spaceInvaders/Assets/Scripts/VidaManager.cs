using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VidaManager : MonoBehaviour
{
    public static VidaManager Instance;
    public TMP_Text texto;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateVidasUI(int vidas)
    {
        if (texto != null)
            texto.text = "Vidas: " + vidas;
    }
}
