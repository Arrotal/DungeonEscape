using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]private int _damage;
    private bool alreadyDamaged = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!alreadyDamaged)
        {
            IDamagable hit = collision.GetComponent<IDamagable>();
            if (hit != null)
            {
                alreadyDamaged = true;
                hit.Damage(_damage);
                StartCoroutine(ResetDamagable());
            }
        }
    }
    IEnumerator  ResetDamagable()
    {

        yield return new WaitForSeconds(0.5f);
        alreadyDamaged = false;
    }
}
