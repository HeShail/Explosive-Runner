using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyController : MonoBehaviour
{
    public GameObject explosionPrefab;
    private Transform target;
    private NavMeshAgent agent;
    private float radius = 10;
    private float power = 10000;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector3.Distance(transform.position, target.position) <= 2f)
        {

            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            target.GetComponent<Respawner>().Invoke("Respawnear", 1f);
            Destroy(this.gameObject);
        }
        if ((target != null) && (agent.enabled == true)) agent.destination = target.position;

        //Condiciones de muerte
        if (Vector3.Distance(transform.position, target.position) >= 30f) Destroy(gameObject);

        time += Time.deltaTime;

        if (time >= 10f) Destroy(gameObject);
    }
}
