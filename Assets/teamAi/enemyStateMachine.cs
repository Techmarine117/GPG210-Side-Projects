using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum aiStates
{
    attack,
    patrolling,
    chasing,
    drone
}

public class enemyStateMachine : MonoBehaviour
{
   private  aiStates currentState;
    public float speed;
    public GameObject[] wayPoints;
    public GameObject target;
    public Rigidbody rb;
    public GameObject player;
    public float detectionRange;
    public float attackRange;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(aiStates.patrolling);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            
            case aiStates.patrolling:
                Patrolling();
                if (detectionRange >= Vector3.Distance(player.transform.position, gameObject.transform.position))
                {
                ChangeState(aiStates.chasing);

                }
                Debug.Log("patrol");
                break;
            case aiStates.chasing:
                Chasing();
                if(attackRange >= Vector3.Distance(player.transform.position, gameObject.transform.position))
                {
                    ChangeState(aiStates.attack);
                }
                if(detectionRange <= Vector3.Distance(player.transform.position, gameObject.transform.position))
                {
                    ChangeState(aiStates.patrolling);

                }
                Debug.Log("chasing");
                break;
            case aiStates.attack:
                //  SceneManager.LoadScene("");
                Debug.Log("attack");

                break;
           // case aiStates.drone:
                //break;

           
        }
    }

    public void ChangeState(aiStates newState)
    {
        currentState = newState;
    }

    private void Patrolling()
    {
        if (!target)
        {
            getTarget();

        }
        // calculate direction towards the target
        Vector3 dir = target.transform.position - gameObject.transform.position;
        // we are normalizing the direction vector, in order to get a unit vector out of the direction where the magnitude is always = 1
        rb.AddForce(dir.normalized * speed * Time.deltaTime, ForceMode.Impulse);

        if (distanceToTarget() <= 1.5f)
        {
            getTarget();
        }

    }

    public float distanceToTarget()
    {
        float dist = Vector3.Distance(gameObject.transform.position, target.transform.position);
        return dist;
    }

    // sets the target to be a random waypoint from the array of waypoints
    public void getTarget()
    {
        target = wayPoints[Random.Range(0, wayPoints.Length)];
    }

    public void Chasing()
    {

        Vector3 dir = player.transform.position - gameObject.transform.position;
        // we are normalizing the direction vector, in order to get a unit vector out of the direction where the magnitude is always = 1
        rb.AddForce(dir.normalized * speed * Time.deltaTime, ForceMode.Impulse);
    }


}

   