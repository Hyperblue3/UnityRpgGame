using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Diagnostics;

public class Player : GameManager
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public int Coin = 0;

    public Rigidbody2D rb;
    public BoxCollider2D playercollider;
    private Vector2 movementDirection;
    private Transform rotation;
    public Animator anim;
    public Transform Plocation;



    public GameObject MainPlayer;


    public static Player Instance;  // istediðimiz bir objeyi farklý scenelerde ayný özelliklerde çaðýrabilmek için

    public float force;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playercollider = GetComponent<BoxCollider2D>();
        rotation = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        


        LastHit = Time.time;






    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            Instance = this;
            GameObject.DontDestroyOnLoad(gameObject);

        }

    }

    void FixedUpdate()
    {
        

        // karakterin hareket kodu
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(horizontal, vertical);



        rb.MovePosition(rb.position + movementDirection * speed * Time.fixedDeltaTime); // rigidbodyi hareket ettirir. Karakterin duvarlardan sekme sorunu bu kodla düzeltildi.



        // karakterin gittiði yöne dogru spriteyi döndürme
        Vector3 characterScale = transform.localScale;
        if (horizontal < 0)
        {
            characterScale.x = -7;

        }
        if (horizontal > 0)
        {
            characterScale.x = 7;
        }


        // ne iþe yaradýgýný bilmediðim kodlar vol bilmem kaç{}
        transform.localScale = characterScale;

        // Animasyon kontrolleri

        if (movementDirection != Vector2.zero)
            anim.SetBool("isMoving", true);
        else 
            anim.SetBool("isMoving", false);


        
















    }

    // temas halinde hasasr alma
    void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 direction = transform.position - collision.transform.position;

        if (collision.gameObject.CompareTag("Enemy"))
        {





            float currentTime = Time.time;
            if (currentTime - LastHit > Cooldown)
            {
                MainPlayer.GetComponent<Knockback>().PlayFeedback(collision.gameObject);

                healthPoint -= collision.gameObject.GetComponent<GameManager>().DamagePoint;
                //Debug.Log(healthPoint);
                DamagePopup.Create(Plocation.transform.position, DamagePoint);  // text fonksiyonu}
                LastHit = currentTime;

            }







        }
        

    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NextScene"))
        {
            Animator animDoor = collision.gameObject.GetComponent<Animator>();
            animDoor.SetTrigger("DoorOpened");
            yield return new WaitForSeconds(3);
            
            SceneManager.LoadScene(1);


            
            
        }
        if (collision.gameObject.CompareTag("BackScene"))
        {
            Animator animDoor = collision.gameObject.GetComponent<Animator>();
            animDoor.SetTrigger("DoorOpened");
            yield return new WaitForSeconds(3);

            SceneManager.LoadScene(0);


        }






    }
}
   

 
