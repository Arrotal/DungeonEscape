using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEvent : MonoBehaviour
{
    [SerializeField] private GameObject _acid;
    private Spider _spider;
    private void Fire()
    {
        Instantiate(_acid, transform.position, Quaternion.identity);
    }

    private void Start()
    {
        _spider = transform.parent.GetComponent < Spider>();
    }
}
