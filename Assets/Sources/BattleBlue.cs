using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Model
{
    public class BattleBlue : MonoBehaviour
    {
        public float speed = 0.0007f;

        public GameObject MyStarship;

        private GameObject RedStarship;

        public static GameObject BdwadwalueStarship;

        private void Awake()
        {
            BdwadwalueStarship = MyStarship;
        }

        private void Start()
        {
            BdwadwalueStarship = MyStarship;

            RedStarship = BattleRed.RedStarship;
        }

        private void Update()
        {
            BdwadwalueStarship = MyStarship;

            if (RedStarship != null)
            {
                transform.position = Vector2.Lerp(transform.position, RedStarship.transform.position, speed);
            }
            else
            {
                RedStarship = BattleRed.RedStarship;
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
