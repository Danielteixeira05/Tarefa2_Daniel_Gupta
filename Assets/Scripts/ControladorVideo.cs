using UnityEngine;
using UnityEngine.Video;

public class ControladorVideo : MonoBehaviour
{
    public VideoPlayer meuVideoPlayer;
    public string nomeDoVideo;

    void Start()
    {
        string caminho = System.IO.Path.Combine(Application.streamingAssetsPath, nomeDoVideo);
        meuVideoPlayer.url = caminho;
        meuVideoPlayer.Play();
    }
}