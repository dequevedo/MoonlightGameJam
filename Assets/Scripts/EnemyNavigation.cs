using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Pathfinding {
    public class EnemyNavigation : MonoBehaviour
    {
        [Header("Dependencies")]
        public float shootDelay = 1.2f;
        public GameObject spawnObject;
        public GameObject playerObject;
        public float enemyVisionRange;
        public GameObject visionGizmo;
        public float enemyHearingRange;
        public GameObject hearingGizmo;
        public float stoppingDistance;
        public string[] layerMaskStrings;

        [Header("Prefabs")]
        public GameObject projectile;

        [Header("Debugging")]
        public float distanceFromPlayer = 999;
        public float raycastHitDistance = 999;
        public bool seeingPlayer = false;
        public bool hearingPlayer = false;
        private RaycastHit2D hit;
        public AIDestinationSetter destinationSetter;
        public AILerp aiLerp;
        IAstarAI ai;

        void Start()
        {
            playerObject = GameObject.FindGameObjectWithTag("Player");
            ai = GetComponent<Pathfinding.IAstarAI>();
            StartCoroutine("ShootCycle");
        }

        void Update()
        {
            ai.destination = playerObject.transform.position;
            //destinationSetter.target = playerObject.transform;
            /*if(playerObject != null){
                canSeePlayer();
                canHearPlayer();
                calculateDistanceFromPlayer();
                setDestination();
            }*/
        }

        void canSeePlayer(){
            int layerMask = LayerMask.GetMask(layerMaskStrings);
            hit = Physics2D.Raycast(transform.position, playerObject.transform.position - transform.position, enemyVisionRange, layerMask);
            if (hit.collider != null)
            {
                seeingPlayer = (hit.transform.tag == "Player");
                raycastHitDistance = Mathf.Abs(hit.point.y - transform.position.y);
            } else {
                seeingPlayer = false;
            }
        }

        void canHearPlayer(){
            distanceFromPlayer = Vector3.Distance(transform.position, playerObject.transform.position);
            hearingPlayer = (distanceFromPlayer <= enemyHearingRange);
        }

        void calculateDistanceFromPlayer(){
            distanceFromPlayer = Vector3.Distance(transform.position, playerObject.transform.position);
        }

        void setDestination(){
            aiLerp.canMove = !seeingPlayer; //|| (seeingPlayer && (distanceFromPlayer > enemyHearingRange));
            
            if(seeingPlayer){
                destinationSetter.target = playerObject.transform;
            } else if(hearingPlayer){
                destinationSetter.target = playerObject.transform;
            } else {
                destinationSetter.target = spawnObject.transform;
            }
        }

        private IEnumerator ShootCycle()
        {
            yield return new WaitForSeconds(shootDelay);
            if(playerObject != null){
                if(seeingPlayer) Shoot();
                StartCoroutine("ShootCycle");
            }
        }

        void Shoot(){
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            bullet.transform.right = playerObject.transform.position - transform.position;
        }
    }
}