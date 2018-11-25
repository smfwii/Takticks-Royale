using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HpHandler : NetworkBehaviour {
    [SyncVar]
    public int hp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0 || transform.position.y < -50 || GetComponent<NetworkTransform>() == false)
        {
            NetworkServer.Destroy(gameObject);
        }
	}
}
