using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nomeDaProximaCena;

    void Start()
    {
        
        videoPlayer.loopPointReached += TerminouVideo;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nomeDaProximaCena);
        }
    }

    void TerminouVideo(VideoPlayer vp)
    {
        SceneManager.LoadScene(nomeDaProximaCena);
    }
}