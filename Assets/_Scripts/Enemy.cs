using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float HP = 25.0f;
    public GameObject ExplosionPrefab;
    public Transform Goal;

    private NavMeshAgent Agent;

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.SetDestination(Goal.position);

    }

    // Update is called once per frame
    void Update()
    {
        
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
