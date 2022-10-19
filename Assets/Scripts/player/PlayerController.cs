using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;

    public Vector3 lastCollision;
    
    void Start()
    {

    }

    void FixedUpdate()
    {
        float x = -Input.GetAxis("Horizontal");
        float z = -Input.GetAxis("Vertical");

        if(x > 0){agent.SetDestination(new Vector3(transform.position.x + 3, transform.position.y, transform.position.z));}
        if(x < 0){agent.SetDestination(new Vector3(transform.position.x - 3, transform.position.y, transform.position.z));}
        if(z > 0){agent.SetDestination(new Vector3(transform.position.x, transform.position.y, transform.position.z + 3));}
        if(z < 0){agent.SetDestination(new Vector3(transform.position.x, transform.position.y, transform.position.z - 3));}

        if(z < 0 && x < 0){agent.SetDestination(new Vector3(transform.position.x - 3, transform.position.y, transform.position.z - 3));}
        if(z > 0 && x > 0){agent.SetDestination(new Vector3(transform.position.x + 3, transform.position.y, transform.position.z + 3));}
        if(z < 0 && x > 0){agent.SetDestination(new Vector3(transform.position.x + 3, transform.position.y, transform.position.z - 3));}
        if(z > 0 && x < 0){agent.SetDestination(new Vector3(transform.position.x - 3, transform.position.y, transform.position.z + 3));}

        if(x == 0 && z == 0){agent.ResetPath();}

    }

    void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }
}