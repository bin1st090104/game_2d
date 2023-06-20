using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int[] a = new int[10];
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 350;
    
    private bool isGrounded = true;
    private bool isJumping = false;
    private bool isAttack = false;
    private bool isDeath = false;

    private int coin = 0;
    
    private float horizontal;

    private string currentAnimName;

    private Vector3 savePoint;

    // Start is called before the first frame update
    void Start()
    {
        SavePoint();
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeath)
        {
            return;
        }   
        Debug.Log(currentAnimName);
        isGrounded = CheckGrounded();
        //-1 -> 0 -> 1
        horizontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log("Print " + horizontal);
        //vertical = Input.GetAxisRaw("Vertical");
        
        if (isAttack)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if (isGrounded)
        {
            if (isJumping)
            {
                return;
            }

            //jump
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }

            //change anim run
            if (Mathf.Abs(horizontal) > 0.1f)
            {
                ChangeAnim("run");
            }

            //attack
            if (Input.GetKeyDown(KeyCode.C) && isGrounded)
            {
                Attack();
            }
            //throw
            if (Input.GetKeyDown(KeyCode.V) && isGrounded)
            {
                Throw();
            }
        }
        
        //check falling
        if (!isGrounded && rb.velocity.y < 0)
        {
            Debug.Log("to fall");
            ChangeAnim("fall");
            isJumping = false;
        }
   
        //Moving
        if(Mathf.Abs(horizontal) > 0.1f)
        {
            rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime * speed, rb.velocity.y);
            //horizontal > 0 -> tra ve 0, neu horizontal <=0 -> tra ve 180
            transform.rotation = Quaternion.Euler(new Vector3(0, horizontal > 0 ? 0 : 180, 0));
            //transform.localScale = new Vector3(horizontal, 1, 1);
        }
        //idle
        else if(isGrounded)
        {
            ChangeAnim("idle");
            rb.velocity = Vector2.zero;
        }
    }
    
    public void OnInit()
    {
        isDeath = isAttack = false;

        transform.position = savePoint;
        ChangeAnim("idle");
    }

    private bool CheckGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        //if(hit.collider != null)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}

        return hit.collider != null;
    }

    private void Attack()
    {
        Debug.Log(nameof(Attack));
        ChangeAnim("attack");
        isAttack = true;
        Invoke(nameof(ResetAttack), 0.5f);
    }

    private void Throw()
    {
        Debug.Log(nameof(Throw));
        ChangeAnim("throw");
        isAttack = true;
        Invoke(nameof(ResetAttack), 0.5f);
    }

    private void ResetAttack()
    {
        Debug.Log(nameof(ResetAttack));
        ChangeAnim("idle");
        isAttack = false;
    }

    private void Jump()
    {
        isJumping = true;
        ChangeAnim("jump");
        rb.AddForce(jumpForce * Vector2.up);
    }

    private void ChangeAnim(string animName)
    {
        if(currentAnimName != animName)
        {
            Debug.Log("   " + currentAnimName + "-->" + animName);
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
    internal void SavePoint()
    {
        savePoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            ++coin;
            Destroy(collision.gameObject);
        }

        if(collision.tag == "DeathZone")
        {
            isDeath = true;
            ChangeAnim("die");
            Invoke(nameof(OnInit), 1f);
        }
    }
}
