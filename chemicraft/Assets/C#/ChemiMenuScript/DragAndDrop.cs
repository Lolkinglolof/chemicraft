using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class DragAndDrop : MonoBehaviour
{
   
    //public Image Image; // skal slettes... 
    public GameObject potionObject;
    public Color onBeingDragColor;
    //MeshRenderer meshRenderer;
    SpriteRenderer spriteRenderer;
    public Color onEndDragColor;
    Vector3 offset;

    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
       
        spriteRenderer.material.color = onEndDragColor; 
        
       
        transform.position = Input.mousePosition;
        offset = this.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }
    private void OnMouseDrag()
    {
        spriteRenderer.material.color = onBeingDragColor;
        transform.position = Input.mousePosition;
        this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }
}
