using UnityEngine;
using UnityEngine.EventSystems;

public class ArrastarItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    void Awake()
    {
        // Vai buscar os componentes que precisamos automaticamente
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Quando começamos a arrastar: fica meio transparente e deixa de bloquear o rato
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Faz a imagem seguir exatamente a posição do rato
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Quando largamos o botão do rato: volta a ficar 100% visível e sólido
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}