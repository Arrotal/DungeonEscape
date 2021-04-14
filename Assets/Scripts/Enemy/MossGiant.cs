using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : EnemyBase, IDamagable
{
    public int Health { get; set; }

    public override void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("MossGiantIdle") || animator.GetCurrentAnimatorStateInfo(0).IsName("MossGiantHit"))
        {
            if (Mathf.Abs(transform.position.x - player.transform.position.x) > 2)
            {
                animator.SetBool("Incombat", false);
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("MossGiantWalk"))
        {
            CheckDestination();
            Movement();
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("MossGiantAttack"))
        {
            if (!attacking)
            {
                Vector2 direction = player.transform.localPosition - transform.localPosition;
                attacking = true;
                if (direction.x < 0)
                {
                    sprite.flipX = true;
                }
                else
                {
                    sprite.flipX = false;
                }
                StartCoroutine(DelayFlip(1.01f));
            }

        }
    }
    public void Damage(int damage)
    {
        if (health < 0)
            return;
        health -= damage;
        animator.SetTrigger("Hit");

        animator.SetBool("Incombat", true);
        
        if (health <= 0)
        {
            DropGems();
            animator.SetTrigger("Death");
        }
    }
}
