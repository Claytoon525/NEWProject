using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    public bool attack;
    public Transform player;
    public List<Transform> locations;
    private int locationIndex = 0;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        attack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 1f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }
    void InitializePatrolRoute()
    {
        foreach(Transform child in locations)
        {
            locations.Add(child);
        }
    }
    void MoveToNextPatrolLocation()
    {
        if(locations.Count == 0)
        {
            return;
        }
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerInRange")
        {
            agent.destination = player.position;
        }
    }
    public bool canAttack()
    {
        //start coro
        //attack = true;
        if(attack == false)
        {
            StartCoroutine(CountDownTimer());
            attack = true;
        }
        return attack;
    }
     IEnumerator CountDownTimer()
    {
        for(int i = 1; i > 0; i --)
        {
            yield return new WaitForSeconds(1f);
        }
        
    }

}
