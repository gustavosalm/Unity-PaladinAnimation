using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    public int combo = 1;
    private bool canAttack = true /*, walkingY = false, walkingX = false*/; 
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();   
    }

    void Update()
    {
        anim.SetFloat("frontBlend", Input.GetAxis("Vertical"));
        anim.SetFloat("Blend", Input.GetAxis("Horizontal"));
        //anim.SetBool("walking", (walkingX || walkingY));    

        if(Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            StopCoroutine("AttackCD");
            anim.SetBool("attacking", true);
            combo = (combo != 3) ? combo + 1 : 1;
            canAttack = false;
            StartCoroutine("AttackCD");
        }
    }

    public IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(1);
        canAttack = true;
        anim.SetBool("attacking", false);
        anim.SetInteger("attack", combo);
        yield return new WaitForSeconds(2);        
        combo = 1;
        anim.SetInteger("attack", combo);
    }
}
