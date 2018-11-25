using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class SENumberRender : NetworkBehaviour {
    public Text disp;
    public GameObject seholder;

	public override void OnStartClient () {
        for (int i = 0; i < FindObjectsOfType<Spawnstuff>().Length; i++)
        {
            if (FindObjectsOfType<Spawnstuff>()[i].GetComponent<NetworkIdentity>().hasAuthority == true)
            {
                seholder = FindObjectsOfType<Spawnstuff>()[i].gameObject;
                return;
            }
        }
	}
	
	void Update () {
        if (FindObjectOfType<Spawnstuff>() != null)
        {
            //You can use certain HTML tags in textboxes. For some reason.
            disp.text = "<b>" + Mathf.Floor(seholder.GetComponent<Spawnstuff>().SummonEnergy).ToString() + "</b>";
        }
    }
}
