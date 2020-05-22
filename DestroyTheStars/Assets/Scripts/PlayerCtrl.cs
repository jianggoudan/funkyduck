using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int healthPoint = 1;


     public float currentTime = 5f;
    
    void Start()
    {
        pc = this;
        if (animator == null)
          {  animator = gameObject.GetComponent<Animator>();}
        if (playerRB == null)
           { playerRB = gameObject.GetComponent<Rigidbody2D>();}

            
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount > 0)
        {
            jumpPressed = true;
        }
         currentTime -= 1 * Time.deltaTime;
        
        if(currentTime <= 0)
        {
            currentTime = 0;
        }
         if(currentTime==0)
         {
            
            this.healthPoint = 5;
            Debug.Log(healthPoint);
            playerRB.velocity = Vector2.zero;
            playerRB.isKinematic = true;
            animator.SetBool("Die", true);
            GameCtrl.inst.heal();
            GameCtrl.inst.OnFailed();
            
            UImanagere.instance.UpdateHealthBar();
         }
        
      
    }
    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(bottom.position, checkRadius, checkLayer);
        GroundMovement();
        Jump();
        SwitchAnim();
    }
    /// <summary>
    /// 移动
    /// </summary>
    void GroundMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");//只有0 -1 1 三个数字
        playerRB.velocity = new Vector2(h * moveSpeed, playerRB.velocity.y);

        if (h != 0)
            transform.localScale = new Vector3(h * 2, 2, 2);//控制翻转
    }
    /// <summary>
    /// 跳跃
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
    /// 动画
    /// </summary>
    private void SwitchAnim()
    {
        animator.SetFloat("Move", playerRB.velocity.x);
        animator.SetBool("Jump", !isGround);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Star"))
        {
            Destroy(collision.gameObject);
            GameCtrl.inst.JudgeSuccess();
        }
        else if (collision.name.Contains("Trap"))
        {
            
            playerRB.velocity = Vector2.zero;
            playerRB.isKinematic = true;
            animator.SetBool("Die", true);
            GameCtrl.inst.OnFailed();
            this.healthPoint = 0;
            UImanagere.instance.UpdateHealthBar();
        }
        else if (collision.name.Contains("addHealth"))
        {
            
            Destroy(collision.gameObject);
            this.healthPoint++;
            GameCtrl.inst.heal();
           
            Debug.Log(this.healthPoint);
        }
        
    }
}
