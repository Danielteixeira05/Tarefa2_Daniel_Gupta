using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour

{
    [Header("Painéis de Pop-up")]
    public GameObject painelPopupInfo; // Arrastas para aqui o teu POPUP de conteúdo/instruções

    private bool jogoPausado = false;

    void Start()
    {
        // Força o motor do Unity a descongelar mal a cena abre!
        Time.timeScale = 1f;
    }

    // Função para o botão "i" (Informação / Pausa)
    public void AbrirInformacaoEPausar()
    {
        jogoPausado = true;
        painelPopupInfo.SetActive(true); // Abre o pop-up na tela
        Time.timeScale = 0f;            // Congela o tempo do Unity (o relógio para!)
    }

    // Função para o botão "Continuar" dentro do pop-up
    public void ContinuarJogo()
    {
        jogoPausado = false;
        painelPopupInfo.SetActive(false); // Esconde o pop-up
        Time.timeScale = 1f;             // Devolve o tempo ao normal (o relógio volta a contar!)
    }

    // Função para o botão "Sair / Voltar ao Menu" dentro do pop-up
    public void VoltarAoMenuDificuldade()
    {
        Time.timeScale = 1f; // GARANTE que o tempo descongela antes de mudar de cena!
        SceneManager.LoadScene("MenuDificuldade"); // Coloca o nome exato da tua cena de menu
    }
}