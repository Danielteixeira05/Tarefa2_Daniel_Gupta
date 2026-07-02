using UnityEngine;

public class GestorNivel : MonoBehaviour
{
    public int pontos = 0;
    public int totalParaGanhar = 2; // Temos 2 alimentos: maçã e pão
    public GameObject painelVitoria;

    public void GanharPonto()
    {
        pontos++; // Soma 1 ponto

        // Se os pontos chegarem ao total... GANHÁMOS!
        if (pontos >= totalParaGanhar)
        {
            painelVitoria.SetActive(true); // Liga o painel de vitória!
        }
    }
}