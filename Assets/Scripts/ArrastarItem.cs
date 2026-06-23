using UnityEngine;
using UnityEngine.EventSystems;

public class ArrastarItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Vector2 posicaoInicial;

    // NOVA VARIÁVEL: Ajuda a maçã a saber se acertou na fatia!
    public bool naPosicaoCorreta = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        posicaoInicial = rectTransform.anchoredPosition;
        naPosicaoCorreta = false; // Quando pegas nela, ela ainda não está no sítio certo

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // REGRA: Só volta para a madeira se NÃO estiver na posição correta
        if (naPosicaoCorreta == false)
        {
            rectTransform.anchoredPosition = posicaoInicial;
        }
    }
}