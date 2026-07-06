using UnityEngine;

public class HitScript : MonoBehaviour
{
    private GestorNivel gestor;

    void Start()
    {
        // Encontra o GestorNivel que está na cena
        gestor = FindFirstObjectByType<GestorNivel>();
    }

    // Chamado ao clicar na Garrafa de Água
    public void OnHitAgua()
    {
        if (gestor != null)
        {
            // Em vez de somar 1, somamos 2 pontos!
            gestor.pontos += 2;

            // Verifica se com este clique o jogador atingiu ou passou a meta para ganhar
            if (gestor.pontos >= gestor.totalParaGanhar)
            {
                gestor.painelVitoria.SetActive(true);
                FindFirstObjectByType<Temporizador>().PararRelogio();
            }
        }

        // Esconde imediatamente a garrafa clicada
        gameObject.SetActive(false);
    }

    // Chamado ao clicar na Garrafa de Coca-Cola (Ratoeira)
    public void OnHitCoca()
    {
        if (gestor != null)
        {
            // Retira 1 ponto
            gestor.pontos--;

            // Impede que os pontos fiquem abaixo de zero
            if (gestor.pontos < 0)
            {
                gestor.pontos = 0;
            }
        }

        // Esconde imediatamente a garrafa clicada
        gameObject.SetActive(false);
    }
}