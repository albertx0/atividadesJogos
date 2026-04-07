using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 

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
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(nomeDaProximaCena);
        }
    }

    void TerminouVideo(VideoPlayer vp)
    {
        SceneManager.LoadScene(nomeDaProximaCena);
    }
}