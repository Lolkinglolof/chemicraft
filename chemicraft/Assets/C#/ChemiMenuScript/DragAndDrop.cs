using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private LayerMask layers;
    private Transform dragTarget;
   
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
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero, float.PositiveInfinity, layers);
            if(hit)
            {
                dragTarget = hit.transform;
                offset = dragTarget.position - (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
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
        if(Input.GetMouseButton(0)) 
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
