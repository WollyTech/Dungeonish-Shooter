using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Handles Game Over, (expand as needed)

    private SpawnManager _spawnManger;
    private Player _player;

    [SerializeField]
    private bool _isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        _spawnManger = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        _isGameOver = false;
    }

    void Update()
    {
        if (_isGameOver == _player.isAlive())
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        _spawnManger.StopSpawning();
        _isGameOver = true;
    }
}
