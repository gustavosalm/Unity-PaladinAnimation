using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    public int combo = 1;
    private bool canAttack = true, canJump = true /*, walkingY = false, walkingX = false*/; 
    
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

        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            anim.SetBool("jump", true);
            canJump = false;
            StartCoroutine("Jump");
        }
    }

    public IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.4f);
        canJump = true;
        anim.SetBool("jump", false);
    }

    public IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(1.2f);
        canAttack = true;
        anim.SetBool("attacking", false);
        anim.SetInteger("attack", combo);
        yield return new WaitForSeconds(2);        
        combo = 1;
        anim.SetInteger("attack", combo);
    }
}
