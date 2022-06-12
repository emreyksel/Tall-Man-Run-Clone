using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private Vector3 firstTouchPosition;
    private Vector3 curTouchPosition;
    [SerializeField] private float sensitivityMultiplier = 0.01f;
    private float finalTouchX;
    private float xBound = 4f;
    public float speed;
    public float yJumpForce;
    public float zJumpForce;
    public bool canMove = false;
    private bool canRun = false;
    private float runMultiplier = 1.5f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (canRun)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime*runMultiplier);
        }

        if (!canMove)
            return;

        Move();
        SetAnimations();            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JumpStart"))
        {
            rb.AddForce(0, yJumpForce, zJumpForce, ForceMode.Impulse);
            anim.SetBool("Run", false);
            canMove = false;
        }
        else if (other.CompareTag("JumpEnd"))
        {           
            anim.SetBool("Run", true);
            anim.speed = runMultiplier;
            canRun = true;
        }
    }

    public void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            curTouchPosition = Input.mousePosition;

            Vector2 touchDelta = (curTouchPosition - firstTouchPosition);

            finalTouchX = (transform.position.x + (touchDelta.x * sensitivityMultiplier));
            finalTouchX = Mathf.Clamp(finalTouchX, -xBound, xBound);

            transform.position = new Vector3(finalTouchX, transform.position.y, transform.position.z);

            firstTouchPosition = Input.mousePosition;
        }
    }

    private void SetAnimations()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Run", true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Run", false);
        }
    }
}
