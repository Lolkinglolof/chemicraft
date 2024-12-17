using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    RectTransform rectTransform;
    public Image Image;

    // Start is called before the first frame update
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>(); 
        Image = GetComponent<Image>();  
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
        //isDraging =false; 
        transform.position = Input.mousePosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Image.color = new Color32(250, 150, 160, 200);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Image.color = new Color32(255, 255, 255, 255); // Default color
    }
}
