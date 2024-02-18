using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMov : MonoBehaviour
{

    NavMeshAgent agent;

    public List<Transform> wayPoints;
    int index = 0;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  
        agent.destination = wayPoints[index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position,agent.destination) < 2)
        {
            if(index + 1 >= wayPoints.Count) {
                index = 0;
            }
            else
            {
                index++;
            }
            agent.destination = wayPoints[index].transform.position;
        }
    }
}
