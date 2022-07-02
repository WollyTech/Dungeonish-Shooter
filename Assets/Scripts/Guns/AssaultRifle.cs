using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Gun
{
    [SerializeField]
    private GameObject _bulletType;
    private Transform _barrel;

    // Start is called before the first frame update
    void Start()
    {
        _barrel = GameObject.Find("ARBarrel").GetComponent<Transform>();
        if (_barrel == null)
            Debug.LogError("Barrel game object not assigned on AR script!!!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletType, _barrel.position, Quaternion.Euler(0, 0, transform.eulerAngles.z - 90));
    }
}