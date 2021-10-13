using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    [SerializeField]private Canvas canvas = default;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Vector3 firstPosition;

    public AudioSource audioSource;
   

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        firstPosition = transform.position;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }



    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        audioSource.Play();
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        transform.position = firstPosition;
    }

    

    
}
