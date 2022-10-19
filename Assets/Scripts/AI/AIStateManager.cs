using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateManager : MonoBehaviour
{
    public AIBaseState currentState;

    public AIChase Chase = new AIChase();
    public AIFlee Flee = new AIFlee();
    public AIReturn Return = new AIReturn();

    public NavMeshAgent agent;
    public GameObject player;
    public GameObject home;

    bool canSwitchToFlee = true, canSwitchToChase, canSwitchToReturn = true;

    public bool powerPell, playerCollide;

    public GameObject skin, powerpellskin, deathSkin;

    public float baseTime = 5;
    public float timer;
    
    public GameObject[] positions;
    public GameObject currentPosition;
    public int index;

    void Start()
    {
        currentState = Chase;
        currentState.EnterState(this);
        timer = baseTime;
    }


    void Update()
    {
        currentState.UpdateState(this);

        if(powerPell)
        {
            timer -=Time.deltaTime;
            if(timer <= 0)
            {
                powerPell = false;
                timer = baseTime;
            }

            if(playerCollide)
            {
                SwitchToReturn();
                timer -=Time.deltaTime;
                if(timer <= 0)
                {
                    SwitchToChase();
                    timer = baseTime;
                }
            }
            else
            {
                SwitchToFlee();
            }

        }
        else
        {
            SwitchToChase();
        }
    }

    void SwitchToFlee()
    {
        if(canSwitchToFlee)
        {
            canSwitchToChase = true;
            powerpellskin.SetActive(true);
            skin.SetActive(false);
            deathSkin.SetActive(false);
            SwitchState(Flee);
            canSwitchToFlee = false;
            timer = baseTime;
        }
    }
    void SwitchToChase()
    {
        if(canSwitchToChase)
        {
            canSwitchToFlee = true;
            powerpellskin.SetActive(false);
            skin.SetActive(true);
            deathSkin.SetActive(false);
            SwitchState(Chase);
            canSwitchToChase = false;
            timer = baseTime;
            canSwitchToReturn = true;
        }
    }

    void SwitchToReturn()
    {
        if(canSwitchToReturn)
        {
            canSwitchToChase = true;
            powerpellskin.SetActive(false);
            skin.SetActive(false);
            deathSkin.SetActive(true);
            SwitchState(Return);
            canSwitchToReturn = false;
            timer = baseTime;
            canSwitchToChase = true;
        }
    }
    void OnCollisionEnter(Collision collsion)
    {
        currentState.OnCollisionEnter(this, collsion);
    }

    public void SwitchState(AIBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    public void resetDelay()
    {
        Chase.delayed = true;
    }
}


