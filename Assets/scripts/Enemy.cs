
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;




public class EnemyAI : GameManager
{
    public GameObject Enemy;
    public Player player;
    public float speed;
    public float distancebetween;
    private bool isChasing;
    private Animator anim;

    public static EnemyAI Instance;

    private float distance;
   
    private Vector2 initialPosition;
    private Vector2 Enemyposition;

    private Rigidbody2D rb;
    public Transform Enemyloc;

    private float movementSpeed = 5f;





    void Awake()
    {
        initialPosition=transform.position; // oyun baþlar baþlamaz ilk pozisyonun hatýrlanmasý
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       

       

        //player = GameObject.Find("Player");  
        // Sceneler arasý objeyi tutma
       

      



    }
    private void Start()
    {
        
        {
            player = Player.Instance;
            
        }

    }
    void Update()
    {

        Enemyposition = transform.position;  // enemy ai kýsmýnda enemy baþlangýç pozisyonuna dönerkenki mevcut pozisyonun her framede güncellenmesi
        //ChasePlayer2();
        ChasePlayer();


        

       

    }

    void ChasePlayer() {
        // karakterin oyuncuyu kovalama ve spawn yerine dönme kodlarý
        distance = Vector2.Distance(transform.position, player.transform.position);

        Vector2 direction = player.transform.position - transform.forward;
        direction.Normalize();

        if (distance < distancebetween)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            isChasing = true;

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
            isChasing = false;
        }

        // anim kontrolleri
        if (isChasing == true && initialPosition != Enemyposition )  // enemy baþlangýç pozisyonuna dönrkenki animasyon hatasý , initial ve enemyposition ile giderildi
            anim.SetBool("isChasing", true);
        else if (isChasing == false && initialPosition == Enemyposition)
            anim.SetBool("isChasing", false);

    }

    void ChasePlayer2() {
        float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");


        if (horizontalInput == 0 && verticalInput == 0)
        { 
          rb.velocity = Vector2.zero;
            return;
        }
        if (distance < distancebetween)
        { 
        
        }
        rb.velocity = new Vector2(horizontalInput * movementSpeed, verticalInput* movementSpeed);
    
    }

  


    private void OnTriggerEnter2D(Collider2D collision)
    {
          if (collision.gameObject.CompareTag("Weapon"))
        {
            healthPoint -= collision.gameObject.transform.parent.GetComponent<Player>().DamagePoint;
            Debug.Log( healthPoint);
            if (healthPoint < 0)
            { 
             Destroy(gameObject);
            }
            

            

            float currentTime = Time.time;
            if (currentTime - LastHit > Cooldown)
            {
                Enemy.GetComponent<Knockback>().PlayFeedback(collision.gameObject);
                //Debug.Log(healthPoint);
                DamagePopup.Create(Enemyloc.transform.position, DamagePoint);  // text fonksiyonu}
                LastHit = currentTime;

            }

        }
       
    }
    /*private IEnumerator OnCollisionEnter2D(Collision2D collision)// ugrastýrýgm kýsým
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log(rb.constraints);
            yield return new WaitForSeconds(5);
        }
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from the gameobject!");
            
        }
    }
    */

    /* private void OnDestroy()
     {
         if (gameObject != null)
         {
             Enemy = new GameObject(gameObject.name);
         }
         else
         {
             return;
         }

     }

  */



}

 

    