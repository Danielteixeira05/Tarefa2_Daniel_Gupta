using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Adicionado para gerir as cenas corretamente

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
        // Inscreve a função no sistema de eventos do SceneManager
        SceneManager.sceneLoaded += AoCarregarCena;
    }

    void OnDisable()
    {
        // Limpa a inscrição para evitar erros de memória
        SceneManager.sceneLoaded -= AoCarregarCena;
    }

    // Esta é a forma moderna que substitui o OnLevelWasLoaded
    void AoCarregarCena(Scene cena, LoadSceneMode modo)
    {
        ConfigurarCenaAtual();
    }

    void Start()
    {
        ConfigurarCenaAtual();
    }

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

            botaomute.onClick.RemoveAllListeners();
            botaomute.onClick.AddListener(AlternarMute);

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