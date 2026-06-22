using UnityEngine;

public class MoverNuvens : MonoBehaviour
{
    public float velocidade = 50f; 
    public float limiteEsquerdo = -1920f; 
    public float posicaoDireita = 1920f; 

    void Update()
    {
        // Move a imagem para a esquerda
        transform.Translate(Vector3.left * velocidade * Time.deltaTime);

        // Se sair totalmente pelo lado esquerdo, volta para trás da fila na direita
        if (transform.localPosition.x <= limiteEsquerdo)
        {
            transform.localPosition = new Vector3(posicaoDireita, transform.localPosition.y, transform.localPosition.z);
        }
    }
}