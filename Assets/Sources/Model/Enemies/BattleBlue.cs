using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Model
{
    public class BattleBlue : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "RedTeam")
            {
                Destroy(collision.gameObject);
                print("Красый звездалёт уничтожен");
            }
        }
    }
}
