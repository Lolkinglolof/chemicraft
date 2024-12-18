using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private bool spillerendrobobject = false; 
    // Start is called before the first frame update
    private void Start()
    {
        spillerendrobobject = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown1()
    {

        spriteRenderer.material.color = onEndDragColor;
       
        Debug.Log("spilleren smid objectet");
        transform.position = Input.mousePosition;
        offset = this.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        spillerendrobobject = false;
    }
    private void OnMouseDrag()
    {
        spriteRenderer.material.color = onBeingDragColor;
        transform.position = Input.mousePosition;
        this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        if(Input.GetMouseButtonDown(0)) 
        {
            if (spillerendrobobject == true)
            {
                OnMouseDown1();
            }
            else
            {
                Debug.Log("do nothing");
            }
        }
    }
}
