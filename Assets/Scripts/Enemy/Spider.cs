using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : EnemyBase, IDamagable
{
    public int Health { get; set; }

    public override void Update()
    {
    }

    public void Damage(int damage)
    {
        if (health < 0)
            return;
        health -= damage;
        animator.SetTrigger("Hit");
        if (health <= 0)
        {
            DropGems();
            animator.SetTrigger("Death");
        }

    }

    public override void Attack()
    {
        animator.SetTrigger("Attack");
    
    }
}
