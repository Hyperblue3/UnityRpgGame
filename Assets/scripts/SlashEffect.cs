using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffect : MonoBehaviour

{
   
    private Animator animEffect;
    // Start is called before the first frame update
    void Start()
    {
        animEffect = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // animasyon kotnrorlleri
      
        if (Input.GetKeyUp(KeyCode.Space))
        {
           
            animEffect.SetTrigger("isSlashed");

        }
    }
}

