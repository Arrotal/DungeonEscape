using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private int value =10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           Player player=  collision.GetComponent<Player>();
            player.AddGems(value);
            Destroy(this.gameObject);
        }
    }
    public void DiamondValue(int diamondValue)
    {
        value = diamondValue;
    }
}
