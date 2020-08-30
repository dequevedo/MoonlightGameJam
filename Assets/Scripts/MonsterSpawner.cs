using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding {
public class MonsterSpawner : MonoBehaviour
    {
        public GameObject monster;
        public GameObject spawnFX;

        void Start()
        {
            createMonster();
        }

        public void createMonster(){
            StartCoroutine("SpawnNewMonsterCoroutine");
        }

        private IEnumerator SpawnNewMonsterCoroutine()
        {
            yield return new WaitForSeconds(12);
            Instantiate(spawnFX, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1);
            newMonster();
        }

        public void newMonster(){
            GameObject monsterInstance = Instantiate(monster, transform.position, Quaternion.identity);
            monsterInstance.GetComponent<Health>().monsterSpawner = this.gameObject;
            EnemyNavigation enemyNavigation = monsterInstance.GetComponent<EnemyNavigation>();
            enemyNavigation.spawnObject = this.gameObject;
            enemyNavigation.playerObject = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
