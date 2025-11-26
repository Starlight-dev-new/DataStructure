using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections; 




public class Player : Identity
{
    
    [SerializeField] SpriteRenderer SpriteRenderer;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject[] uibuff;
    private InputAction playerInput, jumpInput;
    private bool isOnGrounded = false;
    public bool onBuffSped = false;
    public bool onBuffStar= false;
    public bool haveKey = false;



    
    
    void Awake()
    {
        Time.timeScale = 1;
        // Input
        playerInput = InputSystem.actions.FindAction("Move");
        jumpInput = InputSystem.actions.FindAction("Jump");
        // Add components
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (transform.position.y < -7.5f)
        {
            ui.GetComponent<UI>().EndGame("Game Over");
        }

        // Movement
        transform.Translate(playerInput.ReadValue<Vector2>().x * speed * Time.deltaTime, 0f, 0f);
        if (playerInput.ReadValue<Vector2>().x != Vector2.zero.x)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
        // Flip
        if (playerInput.ReadValue<Vector2>().x != 0)
        {
            SpriteRenderer.flipX = playerInput.ReadValue<Vector2>().x < 0;
        }
        // Jump
        if (jumpInput.WasPressedThisFrame() && isOnGrounded)
        {
            rb.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
            Debug.Log("Jumped");
        }

    }
    // Dectect
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGrounded = true;
            animator.SetBool("Jump", false);

            Debug.Log("On Ground");

        }
        if (collision.gameObject.CompareTag("Key"))
        {
            haveKey = true;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Body")&& onBuffStar == false)
        {
         ui.GetComponent<UI>().EndGame("Game Over");
        } 
        else if (collision.gameObject.CompareTag("Head"))
        {
            Transform enemy = collision.transform.parent;
            Destroy(enemy.gameObject);
        }
        else if (collision.gameObject.CompareTag("Body") && onBuffStar == true)
        {
            Transform enemy = collision.transform.parent;
            Destroy(enemy.gameObject);
        } 


        }
    // Leave Dectect
    void OnCollisionExit2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGrounded = false;
            animator.SetBool("Jump", true);
            
            
            Debug.Log("Off Ground");
        }
    }
     public IEnumerator BuffSped(float addSpeed,float duration)
    {
        
        if (onBuffSped) yield break; // ถ้ามีบัพอยู่แล้วให้หยุดการทำงาน
        uibuff[1].SetActive(true);
        Debug.Log("Speed buff started");
        onBuffSped = true; // ตั้งค่าว่ามีบัพอยู่
        speed += addSpeed; // เพิ่มความเร็วให้ Player  

        yield return new WaitForSeconds(duration); // รอเวลาตามระยะเวลาที่กำหนด
        uibuff[1].SetActive(false);
        Debug.Log("Speed buff ended");
        speed -= addSpeed; // ลดความเร็วกลับไปเท่าเดิม
        onBuffSped = false; // ตั้งค่าว่าไม่มีบัพแล้ว

    }
    public IEnumerator BuffStar(float duration)
    {
        if (onBuffStar) yield break; // ถ้ามีบัพอยู่แล้วให้หยุดการทำงาน
        uibuff[0].SetActive(true);
        onBuffStar = true; // ตั้งค่าว่ามีบัพอยู่
        Debug.Log("Star buff started");

        yield return new WaitForSeconds(duration); // รอเวลาตามระยะเวลาที่กำหนด
        uibuff[0].SetActive(false);
        onBuffStar = false; // ตั้งค่าว่าไม่มีบัพแล้ว
        Debug.Log("Star buff ended");

    }
    


}
