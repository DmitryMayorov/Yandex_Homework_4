using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Model
{
    public class BattleRed : MonoBehaviour
    {
        public float speed = 0.0007f;

        public GameObject MyStarship;

        public static GameObject RedStarship;

        private GameObject BlueStarship;

        private void Awake()
        {
            RedStarship = MyStarship;
        }

        private void Start()
        {
            BlueStarship = BattleBlue.BlueSStarship;

            print(BlueStarship);
        }

        private void Update()
        {
            if (BlueStarship != null)
            {
                transform.position = Vector2.Lerp(transform.position, BlueStarship.transform.position, speed);
            }
            else
            {
                BlueStarship = BattleBlue.BlueSStarship;

                print(BlueStarship);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "BlueTeam")
            {
                Destroy(collision.gameObject);

                print("Синий звездалёт уничтожен");
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(gameObject);
            }
        }
    }
}

