using UnityEngine;

public class placar : MonoBehaviour
{

    public AudioSource source;
    public AudioClip musicaFinal;
    public AudioClip musicaFinal2;

    private bool jogoAcabou = false;

    public static GameObject disco;
    
    public static int jogador = 0, inimigo = 0;
    public GUISkin layout;
    
    public static void score(string wallID){
        if(wallID == null) return;

        if(wallID == "golCima"){
            jogador++; 
            disco.SendMessage("voltar", null, SendMessageOptions.RequireReceiver);     
        }
        else if(wallID == "golBaixo"){
            inimigo++;
            disco.SendMessage("voltar", null, SendMessageOptions.RequireReceiver);
        }
    }

    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 300 - 12, 20, 100, 100), "" + jogador);
        GUI.Label(new Rect(Screen.width / 2 + 300 + 12, 20, 100, 100), "" + inimigo);

        if (jogador == 3){
            GUI.Label(new Rect(Screen.width / 2 - 300, 200, 2000, 1000), "JOGADOR VENCEU");
            if (!jogoAcabou)
            {
                jogoAcabou = true;
                source.clip = musicaFinal;
                source.time = 28f;
                source.Play();
            }
            disco.SendMessage("voltar", null, SendMessageOptions.RequireReceiver);
        } 
        else if (inimigo == 3){
            GUI.Label(new Rect(Screen.width / 2 - 300, 200, 2000, 1000), "MAQUINA VENCEU");
            if (!jogoAcabou)
            {
                jogoAcabou = true;
                source.clip = musicaFinal2;
                source.Play();
            }
            disco.SendMessage("voltar", null, SendMessageOptions.RequireReceiver);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
        disco = GameObject.FindGameObjectWithTag("disco");       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
