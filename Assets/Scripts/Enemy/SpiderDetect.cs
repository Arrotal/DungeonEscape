using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderDetect : MonoBehaviour
{
   private Spider _spiderParent;
    private void Start()
    {
        _spiderParent = GetComponentInParent<Spider>();
    }
   
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _spiderParent.Attack();
        }
    }

}
