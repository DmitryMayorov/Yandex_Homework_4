using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Model
{
    public class PlayerHealth : MonoBehaviour
    {
        public GameObject Picture_Game_Over;
        private int _health = 3;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if ((collision.gameObject.CompareTag("RedTeam") || collision.gameObject.CompareTag("BlueTeam") || collision.gameObject.CompareTag("Enemy")) && _health != 0)
            {
                Destroy(collision.gameObject);

                _health--;

                if (_health == 0)
                {
                    Picture_Game_Over.SetActive(true);

                    print("”ничтожен");
                }
                else
                {
                    print("ќсталось жизней: " + _health);
                }
            }
        }
    }
}
