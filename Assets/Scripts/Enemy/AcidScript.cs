using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidScript : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 2f);
    }
    void Update()
    {
        transform.Translate(Vector2.right*3 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IDamagable hit = collision.GetComponent<IDamagable>();

            if (hit != null)
            {
                hit.Damage(1);
                Destroy(this.gameObject);
            }
        }
    }
}
