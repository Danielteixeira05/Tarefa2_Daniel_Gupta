using UnityEngine;
using UnityEngine.EventSystems;

public class ZonaDrop : MonoBehaviour, IDropHandler
{
    public string alimentoCerto;
    private bool jaOcupado = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && jaOcupado == false)
        {
            if (eventData.pointerDrag.name == alimentoCerto)
            {
                ArrastarItem item = eventData.pointerDrag.GetComponent<ArrastarItem>();
                item.naPosicaoCorreta = true;
                
                eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                jaOcupado = true; 

                // A NOVA LINHA MÁGICA: Avisa o Árbitro para dar 1 ponto!
                FindObjectOfType<GestorNivel>().GanharPonto();
            }
        }
    }
}