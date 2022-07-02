using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //spawn enemies while the player is alive with a 3-5 seconds interval

    [SerializeField]
    private GameObject _enemy;

    private bool _spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnRoutine());
    }

    public void StopSpawning()
    {
        _spawn = false;
        StopCoroutine(spawnRoutine());
    }

    //Coroutine to spawn enemies
    //while game is not over (game manager),
    //wait between 3-5 seconds then
    //spawn enemies at random positions within the arena
    //break loop and stop coroutine

    IEnumerator spawnRoutine()
    {
        while (_spawn == true)
        {
            Vector3 SpawnSpace = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
            Instantiate(_enemy, SpawnSpace, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 4));
        }
    }
}