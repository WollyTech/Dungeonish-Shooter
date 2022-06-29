using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _bulletSpeed;

    private GameObject _container;

    void Start()
    {
        _container = GameObject.Find("Bullet Container");
        if (_container == null)
        {
            Debug.LogError("Bullet container not assigned!!!");
        }

        transform.parent = _container.transform;
    }

    void FixedUpdate()
    {
        Vector3 direction = (Vector3.up) * _bulletSpeed * Time.deltaTime;
        transform.Translate(direction);
        Destroy(this.gameObject, 5f);
    }
}