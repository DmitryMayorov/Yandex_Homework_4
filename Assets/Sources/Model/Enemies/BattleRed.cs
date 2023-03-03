using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Model
{
    public class BattleRed : MonoBehaviour
    {
        private float speed = 0.0005f;

        private GameObject[] enemy;

        private GameObject closest;

        private Vector2 transform_closest;

        private void Update()
        {
            enemy = GameObject.FindGameObjectsWithTag("BlueTeam");

            if (GameObject.FindGameObjectWithTag("BlueTeam") != null)
            {
                transform_closest = FindClosestEnemy().transform.position;

                transform.position = Vector2.Lerp(transform.position, transform_closest, speed);
            }
        }

        GameObject FindClosestEnemy()
        {
            float distance = Mathf.Infinity;

            Vector3 position = transform.position;

            foreach (GameObject go in enemy)
            {
                Vector3 diff = go.transform.position - position;

                float curDistance = diff.magnitude;

                if (curDistance < distance)
                {
                    closest = go;

                    distance = curDistance;
                }
            }
            return closest;
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
