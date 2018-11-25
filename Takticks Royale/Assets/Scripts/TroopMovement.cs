using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class TroopMovement : NetworkBehaviour {
    public float SPEED;
    public int ATTACK;
    public float ATKDELAY;
    public float RANGE;
    public NavMeshAgent agent;
    public Transform target;
    public GameObject targetObject;
    int c;
    float lastDist;
    float atkTime;
    public bool fromServer;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = SPEED;
        atkTime = ATKDELAY;
	}

    void Update () {
        //find the closest target
        lastDist = 9999;
        if (fromServer == true)
        {
            FromClientClass[] enemyUnits = FindObjectsOfType<FromClientClass>();
            for (c = 0; c < enemyUnits.Length; c++)
            {
                if (Vector3.Distance(enemyUnits[c].transform.position, transform.position) < lastDist)
                {
                    target = enemyUnits[c].transform;
                    targetObject = enemyUnits[c].gameObject;
                    lastDist = Vector3.Distance(enemyUnits[c].transform.position, transform.position);
                }
            }
        }
        else
        {
            FromServerClass[] enemyUnits = FindObjectsOfType<FromServerClass>();
            for (c = 0; c < enemyUnits.Length; c++)
            {
                if (Vector3.Distance(enemyUnits[c].transform.position, transform.position) < lastDist)
                {
                    target = enemyUnits[c].transform;
                    targetObject = enemyUnits[c].gameObject;
                    lastDist = Vector3.Distance(enemyUnits[c].transform.position, transform.position);
                }
            }
        }


        //if unit is close enough...
        if (lastDist < 9999)
        {
            if (agent.enabled == true)
            {
                agent.destination = target.position;
            }
            if (Vector3.Distance(transform.position, targetObject.transform.position) <= RANGE)
            {
                if (agent.enabled == true)
                {
                    if (atkTime < 70)
                    {
                        agent.isStopped = true;
                    }
                    else
                    {
                        agent.isStopped = false;
                    }
                }
                if (atkTime <= 0 && targetObject.GetComponent<NavMeshAgent>().enabled == true)
                {
                    targetObject.GetComponent<HpHandler>().hp -= ATTACK;
                    transform.Rotate(0, -40, 0);
                    targetObject.GetComponent<Rigidbody>().isKinematic = false;
                    targetObject.GetComponent<NavMeshAgent>().enabled = false;
                    //targetObject.GetComponent<NetworkTransform>().transformSyncMode = NetworkTransform.TransformSyncMode.SyncRigidbody3D;
                    targetObject.GetComponent<Rigidbody>().AddExplosionForce(5, transform.position, RANGE + 2f, 1);
                    targetObject.GetComponent<DeactivatePhysics>().deactivateTimer = 7;
                    atkTime = ATKDELAY;
                }
            }
            else
            //if there are no enemy units in sight...
            {
                if (agent.enabled == true)
                {
                    agent.isStopped = false;
                }
            }
        }
        else
        {
            if (fromServer == true)
            {
                agent.destination = new Vector3(-32, 2, 0);
            }
            else
            {
                agent.destination = new Vector3(33, 2, 0);
            }

        }
        if (transform.position.y < -50)
        {
            NetworkServer.Destroy(gameObject);
        }

        if (atkTime > 0)
        {
            atkTime -= 15f * Time.deltaTime;
        }
    }
}
