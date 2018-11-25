using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class DeactivatePhysics : NetworkBehaviour {
    public float deactivateTimer;
	// Use this for initialization
	void Start ()
    {
        deactivateTimer = 7f;
    }
	
	// Update is called once per frame
	void Update () {

        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.y) <= 0.5)
        {
            deactivateTimer -= 6f * Time.deltaTime;
            if (deactivateTimer <= 0)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                //GetComponent<NetworkTransform>().transformSyncMode = NetworkTransform.TransformSyncMode.SyncTransform;
                gameObject.GetComponent<NavMeshAgent>().enabled = true;
            }
        }else
        {
            deactivateTimer = 7f;
        }
    }
}
