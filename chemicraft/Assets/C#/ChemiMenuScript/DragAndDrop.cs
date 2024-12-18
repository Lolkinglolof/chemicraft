using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private LayerMask layers; // Layer hvor objekter kan v�lges
    [SerializeField] private Color onBeingDragColor;
    [SerializeField] private Color onEndDragColor;
    [SerializeField] private float throwForceMultiplier = 10f; // Juster kastets kraft
    [SerializeField] private float rotationSpeed = 100f; // Justerbar rotationshastighed
    [SerializeField] private float minRotation = 0f;    // Minimum vinkel
    [SerializeField] private float maxRotation = 90f;   // Maksimum vinkel

    private Transform dragTarget; // Det objekt der bliver dragget
    private Rigidbody2D dragRb; // Rigidbody2D for fysik og kollision
    private Vector3 offset;
    private Vector2 extents;
    private Vector2 dragVelocity; // Velocity, der beregnes ved slip
    private Vector3 lastMousePosition; // Spor musens sidste position for korrekt hastighed

    private SpriteRenderer spriteRenderer;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Start drag
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, layers);
            if (hit.collider != null)
            {
                dragTarget = hit.transform;
                dragRb = dragTarget.GetComponent<Rigidbody2D>(); // Hent Rigidbody2D
                spriteRenderer = dragTarget.GetComponent<SpriteRenderer>();

                spriteRenderer.material.color = onBeingDragColor;

                offset = dragTarget.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset.z = 0;
                extents = dragTarget.GetComponent<SpriteRenderer>().bounds.extents;
                // L�s rotation, s� objektet ikke drejer
                dragRb.freezeRotation = true;
            }
        }

        // Stop drag
        if (Input.GetMouseButtonUp(0) && dragTarget != null)
        {
            spriteRenderer.material.color = onEndDragColor;
            // L�s rotation op for at tillade fri bev�gelse
            dragRb.freezeRotation = false;
            Vector2 throwVelocity = dragVelocity * throwForceMultiplier;
            // Begr�ns velocity for at holde objektet inden for sk�rmens gr�nser
            Vector3 screenBottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 screenTopRight = Camera.main.ViewportToWorldPoint(Vector3.one);
            // Begr�ns rotation speed n�r du smider objectet. 
            float angularVelocity = throwVelocity.x * 4f;
            dragRb.angularVelocity = angularVelocity;
            //g�r s� at du ikke kan smide objectet igennem gr�nsen men dette forh�nder ikke at objectet kan komme igennem gr�nsen. 
            throwVelocity.x = Mathf.Clamp(throwVelocity.x, screenBottomLeft.x - dragTarget.position.x, screenTopRight.x - dragTarget.position.x);
            throwVelocity.y = Mathf.Clamp(throwVelocity.y, screenBottomLeft.y - dragTarget.position.y, screenTopRight.y - dragTarget.position.y);
            //g�r s� at du kan smide objectet af sted men mussens hastighed. 
            dragRb.velocity = throwVelocity;

            dragTarget = null;
            dragRb = null; // Slip referencen til Rigidbody2D
        }

        // Flyt objektet med Rigidbody2D for at undg� kollision
        if (dragTarget != null)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPos.z = 0;

            // Begr�ns objektet til sk�rmens gr�nser
            Vector3 screenBottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 screenTopRight = Camera.main.ViewportToWorldPoint(Vector3.one);

            newPos.x = Mathf.Clamp(newPos.x, screenBottomLeft.x + extents.x, screenTopRight.x - extents.x);
            newPos.y = Mathf.Clamp(newPos.y, screenBottomLeft.y + extents.y, screenTopRight.y - extents.y);

            // Flyt objektet via Rigidbody2D for at respektere kollisioner
            dragRb.MovePosition(newPos);

            // bruger mussesn scroll bare til at rotate rundt. 
            float rotationInput = Input.GetAxis("Mouse ScrollWheel") * rotationSpeed;

            float newRotation = dragTarget.eulerAngles.z - rotationInput * rotationSpeed * Time.deltaTime;

            // Begr�ns rotation til mellem minRotation og maxRotation
            newRotation = Mathf.Clamp(newRotation, minRotation, maxRotation);

            // Anvend rotation
            dragTarget.rotation = Quaternion.Euler(0f, 0f, newRotation);

            // Beregn musens velocity separat (uden at p�virke offset)
            dragVelocity = (newPos - dragTarget.position) / Time.deltaTime; // Sporer musens bev�gelse
        }
    }
}
