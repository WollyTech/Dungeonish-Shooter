using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player == null)
                Debug.LogError("Player script not assigned to coin on trigger!");
            player.AddToCoins();
            Destroy(this.gameObject);
        }
    }
}
