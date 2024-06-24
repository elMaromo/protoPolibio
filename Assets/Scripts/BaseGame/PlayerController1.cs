using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public GameObject arrowPrefab;
    private GameObject arrowInstance;
    private Vector2 dragStartPos;
    private bool isDragging = false;
    private Rigidbody2D rb;
    private Camera cam;
    public float forceMultiply = 10f;
    public float maxForce = 30f;
    public float maxArrowLength = 2f;
    public Transform mouseTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {
        var targetPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0f;
        mouseTransform.position = targetPosition;
        
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
            
            arrowInstance = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = dragStartPos - currentPos;
            float distance = direction.magnitude;
            
            float arrowLength = Mathf.Min(distance, maxArrowLength);
            Vector2 arrowDirection = direction.normalized * arrowLength;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            arrowInstance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); 
            arrowInstance.transform.position = transform.position + (Vector3)arrowDirection.normalized * 0.5f;
            
            arrowInstance.transform.localScale = new Vector3(.5f, arrowLength, .5f);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 forceDirection = dragStartPos - currentPos;
            float force = forceDirection.magnitude*forceMultiply;
            
            float forceMagnitude = Mathf.Min(force, maxForce);
            print(forceMagnitude);
            rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode2D.Impulse);
            
            Destroy(arrowInstance);
            isDragging = false;
        }
    }
}
