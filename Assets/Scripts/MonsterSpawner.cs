using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding {
public class MonsterSpawner : MonoBehaviour
    {
        public GameObject monster;

        void Start()
        {
            GameObject monsterInstance = Instantiate(monster, transform.position, Quaternion.identity);
            EnemyNavigation enemyNavigation = monsterInstance.GetComponent<EnemyNavigation>();
            enemyNavigation.spawnObject = this.gameObject;
            enemyNavigation.playerObject = GameObject.FindGameObjectWithTag("Player");
            
            /*monsterInstance.TryGetComponent<AIDestinationSetter>(out AIDestinationSetter component);
            GameObject monsterTarget = Instantiate(new GameObject(), transform.position, Quaternion.identity);
            component.target = monsterTarget.transform;*/
        }
    }
}
