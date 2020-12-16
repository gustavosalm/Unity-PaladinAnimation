using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    public int combo = 1;
    private bool canAttack = true, walkingY = false, walkingX = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") != 0)
        {
            walkingY = true;
            anim.SetFloat("frontBlend", Input.GetAxis("Vertical"));
        }
        else
        {
            walkingY = false;
            anim.SetFloat("frontBlend", 0);
        }
        if(Input.GetAxis("Horizontal") != 0)
        {
            walkingX = true;
            anim.SetFloat("Blend", Input.GetAxis("Horizontal"));
        }
        else
        {
            walkingX = false;
            anim.SetFloat("Blend", 0);
        }
        anim.SetBool("walking", (walkingX || walkingY));    

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
