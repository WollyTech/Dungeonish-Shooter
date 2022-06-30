using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject _player;

    [SerializeField]
    private int _enemyHealth;

    [SerializeField]
    private float _enemySpeed;

    [SerializeField]
    private int _damage;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player == null)
        {
            Debug.LogError("Player Game Object not assigned on Enemy!!!");
        }
    }

    void Update()
    {
        if (_enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_player != null)
            transform.position = Vector3.MoveTowards(this.transform.position, _player.transform.position, _enemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player == null)
                Debug.LogError("Player component not found on Trigger!!!");
            player.Damage(_damage);
            Destroy(this.gameObject);
        }
    }

    public void DamageEnemy(int damage)
    {
        _enemyHealth -= damage;
    }
}