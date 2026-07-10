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

    private void ConfigurarCenaAtual()
    {
        if (fonteMusica == null)
        {
            fonteMusica = GetComponentInChildren<AudioSource>();
        }

        // Procura pelo botão na nova cena
        GameObject encontrarBotao = GameObject.Find("Botao_Mute");
        if (encontrarBotao != null)
        {
            botaomute = encontrarBotao.GetComponent<Button>();

            // --- AQUI ESTÁ A CORREÇÃO DO BUG ---
            // Remove ouvintes antigos para não acumular e adiciona a função via código!
            botaomute.onClick.RemoveAllListeners();
            botaomute.onClick.AddListener(AlternarMuteGeral);

            // Atualiza o sprite inicial baseado no estado real do som global
            botaomute.image.sprite = (AudioListener.volume == 0f) ? iconeSomMutado : iconeSomLigado;
        }

        if (fonteMusica != null && !fonteMusica.isPlaying)
        {
            fonteMusica.Play();
        }
    }

    // Mudámos para silenciar o JOGO INTEIRO (música + efeitos do quiz)
    public void AlternarMuteGeral()
    {
        // Se encontrar o botão novamente só por segurança
        if (botaomute == null)
        {
            GameObject encontrarBotao = GameObject.Find("Botao_Mute");
            if (encontrarBotao != null) botaomute = encontrarBotao.GetComponent<Button>();
        }

        // Alterna o volume global do Unity (AudioListener)
        if (AudioListener.volume > 0f)
        {
            AudioListener.volume = 0f; // Mute geral
            if (botaomute != null) botaomute.image.sprite = iconeSomMutado;
        }
        else
        {
            AudioListener.volume = 1f; // Som ativo
            if (botaomute != null) botaomute.image.sprite = iconeSomLigado;
        }
    }
}