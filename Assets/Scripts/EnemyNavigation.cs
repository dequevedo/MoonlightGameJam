using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Pathfinding {
    public class EnemyNavigation : MonoBehaviour
    {
        public GameObject spawnObject;
        public GameObject playerObject;
        public float playerDetectionRange;
        public float stoppingDistance;

        [Header("Prefabs")]

        public GameObject projectile;

        [Header("Debugging")]
        public float distanceFromPlayer = 999;
        public float raycastHitDistance = 999;
        public bool playerInSight = false;
        public bool playerInRange = false;
        private RaycastHit2D hit;
        private LineRenderer lineRenderer;
        public AIDestinationSetter destinationSetter;

        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        void Update()
        {
            isPlayerInSight();
            isPlayerInRange();
            updateLineRenderer();

            distanceFromPlayer = Vector3.Distance(transform.position, playerObject.transform.position);

            if(playerInSight && playerInRange){
                destinationSetter.target = playerObject.transform;
                GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
                bullet.GetComponent<Projectile>().setMoveDirection(playerObject.transform.position - transform.position);
            } else {
                destinationSetter.target = spawnObject.transform;
            }
        }

        void isPlayerInSight(){
            //Implementar raycast com layermask
            hit = Physics2D.Raycast(transform.position, playerObject.transform.position - transform.position);
            if (hit.collider != null)
            {
                playerInSight = (hit.transform.tag == "Player");
                raycastHitDistance = Mathf.Abs(hit.point.y - transform.position.y);
            }
        }

        void isPlayerInRange(){
            distanceFromPlayer = Vector3.Distance(transform.position, playerObject.transform.position);
            playerInRange = (distanceFromPlayer <= playerDetectionRange);
        }

        void updateLineRenderer(){
            if(playerInSight){
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, playerObject.transform.position);
            }else{
                lineRenderer.enabled = false;
            }
        }
    }
}