using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Model
{
    public class BattleRed : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "BlueTeam")
            {
                Destroy(collision.gameObject);
                print("Синий звездалёт уничтожен");
            }
        }
    }
}
