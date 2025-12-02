using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float HP = 25.0f;
    public GameObject ExplosionPrefab;
    public Transform[] Waypoints;
    public GameObject EyeObject;

    private NavMeshAgent Agent;
    private int curDest;
    private bool SpottedPlayer;
    private GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.SetDestination(Waypoints[0].position);
        curDest = 0;
        SpottedPlayer = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Check if I can see the player
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(EyeObject.transform.position, transform.forward, out hitInfo);

        if(hit)
        {
            if (hitInfo.transform.CompareTag("Player") )
            {
                Debug.Log($"Found you.");
                SpottedPlayer = true;
                Player = hitInfo.transform.gameObject;
                Agent.SetDestination(hitInfo.transform.position);
            }

        }

        if (SpottedPlayer)
        {
            Agent.SetDestination(Player.transform.position);
        }

        if (!SpottedPlayer)
        {
            if (Agent.pathStatus == NavMeshPathStatus.PathComplete && Agent.remainingDistance < .1f)
            {
                curDest++;
                if (curDest == Waypoints.Length)
                {
                    curDest = 0;
                }
                Agent.SetDestination(Waypoints[curDest].position);
            }
        }

    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        Debug.Log($"Took {damage} points, HP is now {HP}");
        if (HP < 0)
        {
            Instantiate(ExplosionPrefab, transform.position + new Vector3(0, .2f, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
