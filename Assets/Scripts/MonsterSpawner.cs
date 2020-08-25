using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding {
public class MonsterSpawner : MonoBehaviour
    {
        public GameObject monster;
        public bool enableMonsterPatrol = true;
        private Vector2 originalPosition;
        public float randomPositionRadius = 1;

        void Start()
        {
            originalPosition = transform.position;
            if(enableMonsterPatrol) StartCoroutine("MoveSpawnRandomly");

            GameObject monsterInstance = Instantiate(monster, transform.position, Quaternion.identity);
            EnemyNavigation enemyNavigation = monsterInstance.GetComponent<EnemyNavigation>();
            enemyNavigation.spawnObject = this.gameObject;
            enemyNavigation.playerObject = GameObject.FindGameObjectWithTag("Player");
        }

        private IEnumerator MoveSpawnRandomly()
        {
            yield return new WaitForSeconds(Random.Range(1f,3f));
            transform.position = new Vector2(
                originalPosition.x + Random.Range(-randomPositionRadius, randomPositionRadius),
                originalPosition.y + Random.Range(-randomPositionRadius, randomPositionRadius)
                );
            StartCoroutine("MoveSpawnRandomly");
        }
    }
}
