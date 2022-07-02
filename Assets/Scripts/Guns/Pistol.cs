using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    //bullet prefab
    //barrel origin
    [SerializeField]
    private GameObject _bulletType;
    private Transform _barrel;

    void Start()
    {
        _barrel = GameObject.Find("Barrel").GetComponent<Transform>();
        if (_barrel == null)
            Debug.LogError("Barrel Transform not assigned!!!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }
    }

    private void shoot()
    {
        Instantiate(_bulletType, _barrel.position, Quaternion.Euler(0, 0, transform.eulerAngles.z - 90));
    }
}