using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool enableMoving;

    private int rotationInputDirection;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rotationInputDirection = (int)Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if(enableMoving)
        {
            rb.MovePosition(rb.position + transform.forward * forwardSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * Quaternion.AngleAxis(rotationInputDirection * rotationSpeed * Time.fixedDeltaTime, Vector3.up));
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            Debug.DrawRay(transform.position, Vector3.down);
            Debug.Log(hit.collider.tag);
            if(hit.collider.CompareTag("Void"))
            {
                PlacePlank();
            }
        }
    }

    private void PlacePlank()
    {

    }
}
