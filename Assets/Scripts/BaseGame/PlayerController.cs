using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float constantSpeed = 5f;
    public float proportionalSpeedMultiplier = 0.5f;
    public float stoppingDistance = 0.1f;
    public float distanceThreshold = 1.5f;

    private Rigidbody2D rb;
    private Vector3 targetPosition;
    private Camera cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        Cursor.visible = false;
    }

    private void Update()
    {
        targetPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0f;
    }

    private void FixedUpdate()
    {
        var position = transform.position;
        float distanceToMouse = Vector2.Distance(position, targetPosition);

        Vector2 direction = (targetPosition - position).normalized;
        //print(direction);

        float speed = distanceToMouse > distanceThreshold
            ? constantSpeed
            : constantSpeed * (distanceToMouse / distanceThreshold) * proportionalSpeedMultiplier;

        rb.velocity = direction * speed;

       // if (distanceToMouse <= stoppingDistance)
        //{
        //    rb.velocity = Vector2.zero;
        //}
    }
}