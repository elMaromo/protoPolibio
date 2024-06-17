using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerActionsMap controls;
    private Vector2 move;
    private bool isDashing;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    public float mouseSensitivity = 0.1f;
    
    [Header("Mouse Controls")]
    public float constantSpeed = 5f; // Velocidad constante cuando el ratón está lejos
    public float proportionalSpeedMultiplier = 0.5f; 
    public float stoppingDistance = 0.1f; // Distancia de seguridad para detenerse
    public float distanceThreshold = 1.5f; //Distancia a partir la cual la velocidad será constante
    private Vector3 targetPosition;
    private Camera cam;
    
    private void Awake()
    {
        controls = new PlayerActionsMap();

        controls.PlayerMap.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.PlayerMap.Move.canceled += ctx => move = Vector2.zero;

        controls.PlayerMap.Dash.performed += ctx => StartDash();
        controls.PlayerMap.Dash.canceled += ctx => StopDash();

        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
        cam=Camera.main;
    }

    private void OnEnable()
    {
        controls.PlayerMap.Enable();
    }

    private void OnDisable()
    {
        controls.PlayerMap.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(move.x, move.y);

        // Movimiento con delta del ratón
        Vector2 mouseDelta = controls.PlayerMap.Move.ReadValue<Vector2>();
        Vector2 mouseMovement = new Vector2(mouseDelta.x, mouseDelta.y) * mouseSensitivity;

        // Combinamos los movimientos
        Vector2 totalMovement = movement + mouseMovement;

        // Normalizar el movimiento para asegurar que la velocidad sea constante
        if (totalMovement.magnitude > 1)
        {
            totalMovement.Normalize();
        }

        totalMovement *= moveSpeed;

        if (isDashing)
        {
            rb.velocity = totalMovement * dashSpeed / moveSpeed;
        }
        else
        {
            rb.velocity = totalMovement;
        }
        
        //MOVIMIENTO CON RATON
        var position = transform.position;
        float distanceToMouse = Vector2.Distance(position, targetPosition);

        Vector2 direction = (targetPosition - position).normalized;

        float speed = distanceToMouse > distanceThreshold
            ? constantSpeed
            : constantSpeed * (distanceToMouse / distanceThreshold) * proportionalSpeedMultiplier;

        rb.velocity = direction * speed;

        if (distanceToMouse <= stoppingDistance)
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void Update()
    {
        targetPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0f;
    }
    private void StartDash()
    {
        //print("StartDash");
        isDashing = true;
    }

    private void StopDash()
    {
        //print("StopDash");
        isDashing = false;
    }
/*
 public float constantSpeed = 5f;
    public float dashForce = 100f;
    public float proportionalSpeedMultiplier = 0.5f;
    public float stoppingDistance = 0.1f;
    public float distanceThreshold = 1.5f;

    private Rigidbody2D rb;
    private Vector3 targetPosition;
    private Camera cam;

    private PlayerActionsMap controls;
    private Vector2 move;
    private bool isDashing;

    private void Awake()
    {
        controls = new PlayerActionsMap();

        controls.PlayerMap.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.PlayerMap.Move.canceled += ctx => move = Vector2.zero;

        controls.PlayerMap.Dash.performed += ctx => StartDash();
        controls.PlayerMap.Dash.canceled += ctx => StopDash();
    }

    private void StartDash()
    {
        isDashing = true;
    }
    private void StopDash()
    {
        isDashing = false;
    }


    private void OnEnable()
    {
        controls.PlayerMap.Enable();
    }

    private void OnDisable()
    {
        controls.PlayerMap.Disable();
    }
    public void OnMove(InputValue value)
    {
        print("Move");
        rb.velocity = value.Get<Vector2>() * constantSpeed;
    }

    public void OnDash()
    {
        print("Dash");
        rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        Cursor.visible = false;
    }
*/

    
}