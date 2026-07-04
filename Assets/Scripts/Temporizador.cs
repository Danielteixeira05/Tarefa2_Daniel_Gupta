using UnityEngine;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public float tempoFalta = 20f; // Lembra-te de mudar no Unity para 40 no nível Fácil!
    public TMP_Text textoTempo;
    public GameObject painelDerrota; // A caixinha nova para o ecrã de derrota
    private bool aContar = true;

    void Update()
    {
        if (aContar == true)
        {
            tempoFalta -= Time.deltaTime;
            textoTempo.text = Mathf.CeilToInt(tempoFalta).ToString();

            if (tempoFalta <= 0)
            {
                tempoFalta = 0; // Prende no zero para não mostrar números negativos
                textoTempo.text = "0";
                aContar = false; // Para de contar
                
                // Mostra o ecrã de derrota!
                painelDerrota.SetActive(true);
            }
        }
    }

    public void PararRelogio()
    {
        aContar = false;
    }
}