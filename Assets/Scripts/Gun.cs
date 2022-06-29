using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //bullet prefab
    //barrel origin
    [SerializeField]
    private GameObject _bullet;
    private Transform _barrel;

    void Start()
    {
        _barrel = GameObject.Find("Barrel").GetComponent<Transform>();
        if (_barrel == null)
        {
            Debug.LogError("Barrel Transform not assigned!!!");
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            shoot();
        }
    }

    void FixedUpdate()
    {
        #region Point towards mouse
        Vector3 directionToFace = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //calculate somesort of angle to turn to rotation based on direction
        float angle = Mathf.Atan2(directionToFace.y, directionToFace.x) * Mathf.Rad2Deg;
        //turn angle into a quaternion based on axis
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
        #endregion
    }

    private void shoot()
    {
        Instantiate(_bullet, _barrel.position, Quaternion.Euler(0, 0, transform.eulerAngles.z - 90));
    }
}