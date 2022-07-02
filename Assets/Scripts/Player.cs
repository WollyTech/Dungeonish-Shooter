using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private int _health;
    private bool _isAlive = true;

    [SerializeField]
    private int _score = 0;
    [SerializeField]
    private int _coins;

    private List<GameObject> _gunInventory = new List<GameObject>();
    private int _selectedGunID = 0;
    private bool gunHasSpawned = false;

    void Update()
    {
        onDeath();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GunSwitcher();
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    #region Movement Logic
    private void Movement()
    {
        float horizontalInput, verticalInput;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 Direction = new Vector3(horizontalInput, verticalInput, 0) * (_speed * Time.deltaTime);
        transform.Translate(Direction);
    }
    #endregion

    #region Managing health & Damage + communication with Game Manager
    public void Damage(int damage)
    {
        _health -= damage;
    }

    private void onDeath()
    {
        if (_health <= 0)
        {
            _isAlive = false;
            Destroy(this.gameObject);
        }
    }

    public bool isAlive()
    {
        return _isAlive;
    }
    #endregion

    #region Score & Coins (Communication + Logic)
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
    #endregion

    #region Player inventory Management
    public void AddGunsToInventory(GameObject gun)
    {
        _gunInventory.Add(gun);
    }

    private void GunSwitcher()
    {
        if (_selectedGunID + 1 > _gunInventory.Count)
        {
            _selectedGunID = 0;
        }
        if (gunHasSpawned == false)
        {
            Instantiate(_gunInventory[_selectedGunID], transform.position, Quaternion.identity);
            _selectedGunID++;
            gunHasSpawned = true;
        }
        else if (gunHasSpawned == true)
        {
            GameObject gun = GameObject.FindObjectOfType<Gun>().gameObject;
            Destroy(gun);
            Instantiate(_gunInventory[_selectedGunID], transform.position, Quaternion.identity);
            _selectedGunID++;
        }
    }
    #endregion
}