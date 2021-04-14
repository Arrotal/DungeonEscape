using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField]protected int health, speed, gem;
    [SerializeField]protected List<Transform> waypoints;
    protected Animator animator;
    protected Rigidbody2D rigidbody;
    protected SpriteRenderer sprite;
    protected bool idling, attacking;
    protected Player player;
    [SerializeField]protected GameObject _diamonds;

    protected int _destination;
    public virtual void  Attack()
    { 
    
    }

    public abstract void Update();
    protected void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[_destination].position, speed * Time.deltaTime);
        
            if (transform.position.x < waypoints[_destination].position.x)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        
    }

    protected void CheckDestination()
    {
        if (transform.position.x == waypoints[_destination].position.x)
        {
            animator.SetTrigger("Idle");
            if (_destination == waypoints.Count - 1)
            {
                _destination = 0;
            }
            else
            {
                _destination++;
            }
        }
    }
    protected void DropGems()
    {
       GameObject diamondDrop = Instantiate(_diamonds, transform.position, Quaternion.identity);
        diamondDrop.GetComponent<Diamond>().DiamondValue(gem);
    }

    protected IEnumerator DelayFlip(float attackduration)
    {
        yield return new WaitForSeconds(attackduration);
        attacking = false;
    
    }
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        _destination = 0;
        player = FindObjectOfType<Player>().GetComponent<Player>();
    }
  
}
