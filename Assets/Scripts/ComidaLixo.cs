using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using TMPro; // Não te esqueças de ter o TextMeshPro no projeto

public class ComidaLixo : MonoBehaviour, IEndDragHandler
{
    public GameObject painelAviso;      // O painel que contém o Batata e o Balão
    public TMP_Text textoAviso;          // O componente de texto do TMP
    public string mensagemADigitar = "não é saudável"; // A mensagem a escrever
    public float velocidadeEscrita = 0.05f;           // Velocidade (segundos por letra)
    public float tempoMostrarFinal = 2f;               // Quanto tempo fica no final

    public void OnEndDrag(PointerEventData eventData)
    {
        // Ativa o painel
        painelAviso.SetActive(true);

        // Reinicia e começa a escrever
        StopAllCoroutines();
        StartCoroutine(EscreverMensagem());
    }

    IEnumerator EscreverMensagem()
    {
        textoAviso.text = ""; // Limpa o texto primeiro

        // Escreve cada letra com um pequeno atraso
        foreach (char letra in mensagemADigitar.ToCharArray())
        {
            textoAviso.text += letra;
            yield return new WaitForSeconds(velocidadeEscrita);
        }

        // Espera o tempo final antes de esconder
        yield return new WaitForSeconds(tempoMostrarFinal);
        painelAviso.SetActive(false);
    }
}