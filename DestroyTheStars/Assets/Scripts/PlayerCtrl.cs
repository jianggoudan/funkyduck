﻿


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D playerRB;
    public Transform bottom;
    public static PlayerCtrl pc;

    public float moveSpeed = 1;
    public float jumpForce = 5;
    public LayerMask checkLayer;
    public float checkRadius = 0.1f;

    private bool isGround, isJump;
    private bool jumpPressed;
    private int jumpCount;
    public static int healthPoint = 1;
    public Vector3 startPosition;

    public static int score;
    public static int bananaScore;
   

    void Start()
    {
        pc = this;
        if (animator == null)
        { animator = gameObject.GetComponent<Animator>(); }
        if (playerRB == null)
        { playerRB = gameObject.GetComponent<Rigidbody2D>(); }


    }
    private void Update()//character move
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount > 0)
        {
            jumpPressed = true;
        }
        if (healthPoint <= 0)
        {
            healthPoint = 0;
        }
    }
    private void Awake()
    {
        startPosition = transform.position;//to set the player back to the spawn position if he dies
    }
    void FixedUpdate()//inspect if character is on the ground
    {
        isGround = Physics2D.OverlapCircle(bottom.position, checkRadius, checkLayer);
        GroundMovement();
        Jump();
        SwitchAnim();
    }

    void GroundMovement()//move
    {
        float h = Input.GetAxisRaw("Horizontal");//只有0 -1 1 三个数字
        playerRB.velocity = new Vector2(h * moveSpeed, playerRB.velocity.y);

        if (h != 0)
            transform.localScale = new Vector3(h * 2, 2, 2);//控制翻转
    }
    /// <summary>
    /// jump
    /// </summary>
    void Jump()
    {
        if (isGround)
        {
            jumpCount = 2;
            isJump = false;
        }

        if (jumpPressed && isGround)
        {
            isJump = true;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;//每0.02秒检测按键是否松开
        }
        else if (jumpPressed && jumpCount > 0 && !isGround)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }

    }
    /// <summary>
    /// animations
    /// </summary>
    private void SwitchAnim()
    {
        animator.SetFloat("Move", playerRB.velocity.x);
        animator.SetBool("Jump", !isGround);
    }
    private void OnTriggerEnter2D(Collider2D collision)//if character touches some items.
    {
        if (collision.name.Contains("Star"))
        {
            Destroy(collision.gameObject);
            GameCtrl.inst.JudgeSuccess();
            score++;
            Debug.Log(score);
        }
        else if (collision.name.Contains("Trap"))
        {
            loseHealthPoint();
        }
        else if (collision.name.Contains("addHealth"))
        {

            Destroy(collision.gameObject);
            healthPoint += 1;
            GameCtrl.inst.heal();
           
        }
        else if(collision.name.Contains("banana"))
        {
            Destroy(collision.gameObject);
           PlayerCtrl.bananaScore++;
            Debug.Log(bananaScore);
            GameCtrl.inst.addBanana();
        }


    }
    public void healthPointZero()//lifeline
    {
        healthPoint = 0;
        GameCtrl.inst.OnFailed();
        playerRB.velocity = Vector2.zero;
        playerRB.isKinematic = true;
        animator.SetBool("Die", true);
        GameCtrl.inst.heal();
    }
    public void loseHealthPoint()//decrease health points 
    {
        healthPoint -= 1;
        JudgeGame();
        GameCtrl.inst.heal();
    }
    public void JudgeGame()//end game if health point is 0
    {
        if (healthPoint > 0)
        { transform.position = startPosition; }

        else if (healthPoint == 0)
        {
            GameCtrl.inst.OnFailed();
            playerRB.velocity = Vector2.zero;
            playerRB.isKinematic = true;
            animator.SetBool("Die", true);

        }
    }



}