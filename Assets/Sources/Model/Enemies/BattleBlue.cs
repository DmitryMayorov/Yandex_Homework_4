using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Model
{
    public class BattleBlue : MonoBehaviour
    {
        public int speed = 1;
        public GameObject[] enemy;
        public GameObject closest;
        
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

        private void Update()
        {
            enemy = GameObject.FindGameObjectsWithTag("RedTeam");
            
            transform.position = Vector2.Lerp(transform.position, closest.transform.position, speed);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "RedTeam")
            {
                Destroy(collision.gameObject);
                print("������ �������� ���������");
            }
        }
    }
}
