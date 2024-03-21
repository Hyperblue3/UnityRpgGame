using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator anim;
    public Animator animEffect;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // animasyon kotnrorlleri
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isSlashing", true);
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isSlashing", false);
            animEffect.SetTrigger("isSlashed");

        }
    }
}
