using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool enableMoving;
    [SerializeField] private Transform planksPoint;
    [SerializeField] private Transform placedPlanksParent;

    private int rotationInputDirection;
    private Rigidbody rb;
    private List<Transform> planks = new List<Transform>();
    private Coroutine dieCoroutine;

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
            //Debug.Log(hit.collider.tag);
            if(hit.collider.CompareTag("Void"))
            {
                PlacePlank();
            }
            else
            {
                if(dieCoroutine != null)
                {
                    StopCoroutine(dieCoroutine);
                    dieCoroutine = null;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Plank"))
        {
            collision.rigidbody.isKinematic = true;
            collision.transform.SetParent(transform);
            collision.transform.SetPositionAndRotation(planksPoint.position + Vector3.up * planks.Count * 0.2f, transform.rotation);
            planks.Add(collision.transform);
        }
    }

    private void PlacePlank()
    {
        if(planks.Count == 0)
        {
            if(dieCoroutine == null)
            {
                dieCoroutine = StartCoroutine(DieCoroutine());
            }
            return;
        }

        if(dieCoroutine != null)
        {
            StopCoroutine(dieCoroutine);
            dieCoroutine = null;
        }

        Transform lastPlank = planks[planks.Count - 1];
        lastPlank.SetParent(placedPlanksParent);
        lastPlank.position = transform.position + Vector3.down * 0.2f;
        BoxCollider plankCollider = lastPlank.GetComponent<BoxCollider>();
        plankCollider.size = plankCollider.size + new Vector3(0, 0, 2f);
        planks.RemoveAt(planks.Count - 1);
    }

    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(2f);
        enableMoving = false;
        rb.isKinematic = false;
        GameManager.Instance.GameOver();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(transform.position, Vector3.down);
    }
}
