using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDatabase : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _guns = new List<GameObject>();

    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (_player == null)
            Debug.LogError("Player script not assigned in Gun Database!!!");

        foreach(var gun in _guns)
        {
            _player.AddGunsToInventory(gun);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
