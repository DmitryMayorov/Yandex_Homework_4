using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Model
{
    public class BattleBlue : MonoBehaviour
    {
        public float speed = 0.0007f;

        private GameObject MyStarship;

        private GameObject RedStarship;

        public static GameObject BlueSStarship;

        private void Start()
        {
            BlueSStarship = MyStarship;

            RedStarship = BattleRed.RedStarship;
        }

        private void Update()
        {
            if (RedStarship != null)
            {
                transform.position = Vector2.Lerp(transform.position, RedStarship.transform.position, speed);
            }
        }

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
