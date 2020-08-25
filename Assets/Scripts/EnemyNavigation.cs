using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    public bool playerInSight = false;
    private NavMeshAgent agent;
    private RaycastHit hit;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stoppingDistance;
    }

    void Update()
    {
        isPlayerInSight();
        updateLineRenderer();

        distanceFromPlayer = Vector3.Distance(transform.position, playerObject.transform.position);

        if(distanceFromPlayer <= playerDetectionRange){
            agent.SetDestination(playerObject.transform.position);
            //Instantiate(projectile, transform.position, transform.rotation);
        } else {
            agent.SetDestination(spawnObject.transform.position);
        }
    }

    void isPlayerInSight(){
        if (Physics.Raycast(transform.position, playerObject.transform.position - transform.position, out hit, playerDetectionRange) 
        && hit.transform.tag == "Player"){
            playerInSight =  true;
        } else {
            playerInSight =  false;
        }
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
