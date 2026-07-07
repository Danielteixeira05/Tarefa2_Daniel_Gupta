using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MecanicaQuiz : MonoBehaviour
{
    [Header("Sprites das Comidas")]
    public List<Sprite> comidasSaudaveis;
    public List<Sprite> comidasNaoSaudaveis;

    [Header("Componente do Ecrã")]
    public Image imagemExibicao; // Arrasta aqui o objeto "AlimentoExibido"

    private bool alimentoAtualEhSaudavel;
    private GestorNivel gestorNivel;

    void Start()
    {
        // Encontra o teu GestorNivel atual na cena
        gestorNivel = FindFirstObjectByType<GestorNivel>();
        ProximoAlimento();
    }

    void ProximoAlimento()
    {
        // Escolhe aleatoriamente se vai mostrar uma comida saudável (true) ou lixo (false)
        alimentoAtualEhSaudavel = (Random.value > 0.5f);

        if (alimentoAtualEhSaudavel && comidasSaudaveis.Count > 0)
        {
            int index = Random.Range(0, comidasSaudaveis.Count);
            imagemExibicao.sprite = comidasSaudaveis[index];
        }
        else if (!alimentoAtualEhSaudavel && comidasNaoSaudaveis.Count > 0)
        {
            int index = Random.Range(0, comidasNaoSaudaveis.Count);
            imagemExibicao.sprite = comidasNaoSaudaveis[index];
        }
    }

    // Ligar ao OnClick do BOTAO_CERTO
    public void CliqueiSaudavel()
    {
        if (alimentoAtualEhSaudavel)
        {
            gestorNivel.GanharPonto(); // Corre o teu script: ganha ponto e testa se ganhou!
        }
        else
        {
            // Se errar, tira 1 ponto (opcional, protege para não ser menor que 0)
            gestorNivel.pontos = Mathf.Max(0, gestorNivel.pontos - 1);
        }
        ProximoAlimento();
    }

    // Ligar ao OnClick do BOTAO_ERRADO
    public void CliqueiNaoSaudavel()
    {
        if (!alimentoAtualEhSaudavel)
        {
            gestorNivel.GanharPonto(); // Corre o teu script: ganha ponto e testa se ganhou!
        }
        else
        {
            gestorNivel.pontos = Mathf.Max(0, gestorNivel.pontos - 1);
        }
        ProximoAlimento();
    }
}