using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void TrocarCena(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}