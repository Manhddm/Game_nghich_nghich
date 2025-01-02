using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 20f ;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    public int countJump = 0;
    public bool canJump = false;
    public float jumpTimeCounter = 0f;
    public float jumpTime = 0.2f;
    private Rigidbody2D rb2d;
    /*
     * Cac task
     *      xu ly di chuyen nhan vat: di, nhay
     *      xoay nhan vat
     */

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJump();   
    }

    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(moveHorizontal * moveSpeed, rb2d.linearVelocity.y);
        if (moveHorizontal > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveHorizontal < 0) transform.localScale = new Vector3(-1, 1, 1);
    }
    
    private void HandleJump()
    {
        // if (Input.GetButtonDown("Jump") && canJump)
        // {
        //     rb2d.AddForce(Vector2.up * jumpForce);
        //     
        // }
        // canJump = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        if (Input.GetButtonDown("Jump") && countJump < 2 && jumpTimeCounter >= jumpTime)
        {
            Debug.Log(countJump);
            rb2d.linearVelocity = Vector2.up * jumpForce;
            countJump++;
            jumpTimeCounter = 0;
        }
        canJump = Physics2D.OverlapCircle(groundCheck.position, 0.001f, groundLayer);
        //canJump tra ve true neu co va cham voi groundLayer
        if (canJump) countJump = 0;
        jumpTimeCounter += Time.deltaTime;
    }
}
