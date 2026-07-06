using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunnerNivel3 : MonoBehaviour
{
    [Header("Configurações de Tempo")]
    [Range(0f, 2f)][SerializeField] private float tempoVisivel = 1.2f; // Quanto tempo cada garrafa fica exposta

    [Header("Listas de Objetos (Spots/Posições)")]
    [SerializeField] private List<GameObject> spotsAgua; // Arrasta para aqui os GameObjects das Garrafas de Água
    [SerializeField] private List<GameObject> spotsCoca; // Arrasta para aqui os GameObjects das Garrafas de Coca-Cola

    private System.Random random;
    private Temporizador temporizador;

    void Start()
    {
        random = new System.Random();
        temporizador = FindFirstObjectByType<Temporizador>();

        // Garantir que todas começam desativadas
        DesativarTodas();

        // Iniciar a rotina de alternância aleatória
        StartCoroutine(CicloGarrafas());
    }

    IEnumerator CicloGarrafas()
    {
        // Enquanto o temporizador estiver a contar (tempoFalta > 0)
        while (temporizador != null && temporizador.tempoFalta > 0)
        {
            yield return new WaitForSeconds(tempoVisivel);

            // 1. Esconder tudo o que estava visível
            DesativarTodas();

            // 2. Decidir aleatoriamente se vai aparecer Água (70% chance) ou Coca-Cola (30% chance)
            // Podes ajustar estes valores para equilibrar a dificuldade!
            if (random.NextDouble() < 0.70)
            {
                // Ativa uma Garrafa de Água aleatória se houver elementos na lista
                if (spotsAgua.Count > 0)
                {
                    int indexAleatorio = random.Next(0, spotsAgua.Count);
                    spotsAgua[indexAleatorio].SetActive(true);
                }
            }
            else
            {
                // Ativa uma Garrafa de Coca-Cola aleatória se houver elementos na lista
                if (spotsCoca.Count > 0)
                {
                    int indexAleatorio = random.Next(0, spotsCoca.Count);
                    spotsCoca[indexAleatorio].SetActive(true);
                }
            }
        }

        // Se o jogo acabar por tempo, garante que limpa o ecrã
        DesativarTodas();
    }

    private void DesativarTodas()
    {
        spotsAgua.ForEach(g => g.SetActive(false));
        spotsCoca.ForEach(g => g.SetActive(false));
    }
}