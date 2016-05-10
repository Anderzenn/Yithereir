using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;
    public PauseMenu pauseMenu;

    private float attackTimer = 0f;
    private float attackCd = 0.3f;

    public Collider2D attackTrigger;

    private Animator anim;
    
    void Start()
    {
        pauseMenu = pauseMenu.GetComponent<PauseMenu>();
    }

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        /* if (pauseMenu.paused == false)
         {
             if (Input.GetMouseButtonDown(0) && !attacking)
             {
                 attacking = true;
                 attackTimer = attackCd;

                 attackTrigger.enabled = true;
             }

             if (attacking)
             {
                 if (attackTimer >= 0)
                 {
                     attackTimer -= Time.deltaTime;
                 }
                 else
                 {
                     attacking = false;
                     attackTrigger.enabled = false;
                 }
             }

             anim.SetBool("Attacking", attacking);
         } else if (pauseMenu.paused == true || attacking == true && pauseMenu.paused == true)
         {
             attacking = false;
         }*/

    }

}
