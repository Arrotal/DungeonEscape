using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : EnemyBase, IDamagable
{
    public int Health { get; set; }



    public override void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("SkeletonIdle")|| animator.GetCurrentAnimatorStateInfo(0).IsName("SkeletonHit"))
        {
            if (Mathf.Abs(transform.position.x - player.transform.position.x) > 2)
            {
                animator.SetBool("Incombat", false);
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("SkeletonWalk"))
            {
            CheckDestination();
            Movement();
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("SkeletonAttack"))
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
                StartCoroutine(DelayFlip(2.02f));
            }
        }
    }
    public void Damage(int damage)
    {
        if (health < 0)
            return;
        health -= damage;
        animator.SetTrigger("Hit");
        Debug.Log(health);
        animator.SetBool("Incombat", true);
        if (health <= 0)
        {
            DropGems();
            animator.SetTrigger("Death");
            
        }
    }
}
