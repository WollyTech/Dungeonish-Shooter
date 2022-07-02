using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gun : MonoBehaviour
{
    public string gunName;
    public int gunID;
    public float fireRate;
    private protected float nextFire = 0;
    public int price;
    public int pointsForUnlock;

    void Awake()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (player == null)
            Debug.LogError("Player transform is not assigned on Gun script!!!");
        transform.parent = player.transform;
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
}