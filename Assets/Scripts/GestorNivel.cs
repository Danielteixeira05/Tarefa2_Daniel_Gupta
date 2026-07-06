using UnityEngine;

public class GestorNivel : MonoBehaviour
{
    public int pontos = 0;
    public int totalParaGanhar = 4;
    public GameObject painelVitoria;

    public void GanharPonto()
    {
        pontos++;

        if (pontos >= totalParaGanhar)
        {
            painelVitoria.SetActive(true);

            // Manda o temporizador parar
            FindFirstObjectByType<Temporizador>().PararRelogio();
        }
    }
}