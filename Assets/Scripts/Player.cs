using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //we are to create movement based on horizontal and vertical axis inputs
    [SerializeField]
    private float _speed;

    [SerializeField]
    private int _health;
    private bool _isAlive = true;

    [SerializeField]
    private int _score = 0;
    [SerializeField]
    private int _coins;

    void Update()
    {
        if (_health <= 0)
        {
            _isAlive = false;
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        float horizontalInput, verticalInput;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 Direction = new Vector3(horizontalInput, verticalInput, 0) * (_speed * Time.deltaTime);
        transform.Translate(Direction);
    }

    public void Damage(int damage)
    {
        _health -= damage;
    }

    public bool isAlive()
    {
        return _isAlive;
    }

    public void AddToScore(int pointsToAdd)
    {
        _score += pointsToAdd;
    }

    public int FinalPoints()
    {
        return _score;
    }

    public void AddToCoins()
    {
        _coins++;
    }

    public int CoinsTotal()
    {
        return _coins;
    }
}