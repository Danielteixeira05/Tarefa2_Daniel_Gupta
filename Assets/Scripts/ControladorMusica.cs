using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorMusica : MonoBehaviour
{
    private static ControladorMusica instanciaUnica;

    public AudioSource fonteMusica;
    private Button botaomute;

    public Sprite iconeSomLigado;
    public Sprite iconeSomMutado;

    void Awake()
    {
        if (instanciaUnica != null && instanciaUnica != this)
        {
            Destroy(gameObject);
            return;
        }

        instanciaUnica = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += AoCarregarCena;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= AoCarregarCena;
    }

    void AoCarregarCena(Scene cena, LoadSceneMode modo)
    {
        ConfigurarCenaAtual();
    }

    void Start()
    {
        ConfigurarCenaAtual();
    }

    // A função aqui dentro da classe está correta como private
    private void ConfigurarCenaAtual()
    {
        if (fonteMusica == null)
        {
            fonteMusica = GetComponentInChildren<AudioSource>();
        }

        GameObject encontrarBotao = GameObject.Find("Botao_Mute");
        if (encontrarBotao != null)
        {
            botaomute = encontrarBotao.GetComponent<Button>();

            // Atualiza o sprite inicial baseado no estado real da música
            botaomute.image.sprite = fonteMusica.mute ? iconeSomMutado : iconeSomLigado;
        }

        if (fonteMusica != null && !fonteMusica.isPlaying)
        {
            fonteMusica.mute = false;
            fonteMusica.Play();
        }
    }

    public void AlternarMute()
    {
        if (fonteMusica == null || botaomute == null) return;

        fonteMusica.mute = !fonteMusica.mute;
        botaomute.image.sprite = fonteMusica.mute ? iconeSomMutado : iconeSomLigado;
    }
}