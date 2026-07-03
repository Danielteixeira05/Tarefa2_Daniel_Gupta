using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{
    public float tempoFalta = 20f;
    public TMP_Text textoTempo;
    private bool aContar = true;

    void Update()
    {
        if (aContar == true)
        {
            tempoFalta -= Time.deltaTime;
            textoTempo.text = Mathf.CeilToInt(tempoFalta).ToString();

            if (tempoFalta <= 0)
            {
                SceneManager.LoadScene("MenuDificuldade");
            }
        }
    }

    public void PararRelogio()
    {
        aContar = false;
    }
}