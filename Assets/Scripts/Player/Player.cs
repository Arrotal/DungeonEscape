using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamagable
{
    private Rigidbody2D _rigidbody;
    private float _xVelocity, _jumpHeight = 5f;
    [SerializeField]private float _speed;
    private RaycastHit2D _hit;
    [SerializeField]private LayerMask _ground;
    private Animator _playerAnimator,_swordAnimator;
    private SpriteRenderer _playerSprite, _swordSprite;
    public int _gemTotal;
    private int previousTotal;
    public int Health { get; set; }
    void Start()
    {
        _rigidbody=GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponentInChildren<Animator>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordAnimator = transform.GetChild(1).GetComponent<Animator>();
        _swordSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
        _gemTotal = 0;

        UIManager.Instance.HealthUpdate(Health);
        UIManager.Instance.GemCount(_gemTotal);

    }
    void Update()
    {
        if (Health > 0 &&!_playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerHit"))
        {
            Movement();
            Attack();
            if (_rigidbody.velocity.y == 0)
            {

                _swordAnimator.SetBool("Jump", false);
                _playerAnimator.SetBool("Jump", false);
            }
        }
        else
        {

            _rigidbody.velocity = new Vector2(0, 0);
        }
    }

    private void Attack()
    {
        if (CrossPlatformInputManager.GetButtonDown("A_Button"))
        {
            
                _playerAnimator.SetTrigger("Swing");
                _swordAnimator.SetTrigger("Attack");
                _swordSprite.flipX = true;
        }

    }
    private void Movement()
    {
        Jump();
        _xVelocity = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        _rigidbody.velocity = new Vector2(_xVelocity*_speed, _rigidbody.velocity.y);
        if (_rigidbody.velocity.x != 0)
        {
            if (_rigidbody.velocity.x < 0)
            {
                _playerSprite.flipX = true;
                _swordSprite.flipY = true;
            }
            else
            { _playerSprite.flipX = false;
                _swordSprite.flipY = false;
            }
            _playerAnimator.SetBool("Run", true);
        }
        else
        {
            _playerAnimator.SetBool("Run", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) ||CrossPlatformInputManager.GetButtonDown("B_Button") && Grounding())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpHeight);
            _playerAnimator.SetBool("Jump",true);
            _swordAnimator.SetBool("Jump", true);
            _playerAnimator.SetTrigger("Jumping");
        }
    }

    private bool Grounding()
    {
            _hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _ground.value);
            if (_hit.collider != null)
            {return true;}

        _swordAnimator.SetBool("Jump", false);
        _playerAnimator.SetBool("Jump", false);
        return false;
    }

    public void Damage(int damage)
    {
        Health -= damage;
        if (Health < 0)
            Health = 0;
        Debug.Log(Health);
        UIManager.Instance.HealthUpdate(Health);
        _playerAnimator.SetTrigger("Hit");
        if(Health <=0)
        _playerAnimator.SetTrigger("Death");
    }

    public void AddGems(int gemValue)
    {
        _gemTotal += gemValue;
        
            StartCoroutine(GemAdding());
        
    }

    IEnumerator GemAdding()
    {
        while(previousTotal< _gemTotal)
        {
            yield return new WaitForSeconds(0.07f);
            previousTotal++;
            UIManager.Instance.GemCount(previousTotal);
        }
        UIManager.Instance.GemCount(_gemTotal);

    }
    public int GemCount()
    {
        return _gemTotal;
    }
    public void GemRemove(int amount)
    {
        _gemTotal -= amount;
    }
}
