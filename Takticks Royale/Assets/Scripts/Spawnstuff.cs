using UnityEngine;
using UnityEngine.Networking;

public class Spawnstuff: NetworkBehaviour {
    public float SummonEnergy;
    public GameObject SoldierProto;
    public GameObject ArcherProto;
    public GameObject ClubsterProto;
    public GameObject RedSoldierProto;
    public GameObject RedArcherProto;
    public GameObject RedClubsterProto;
    public Vector3 p1Spawn = new Vector3(33, 2, 0);
    public Vector3 p2Spawn = new Vector3(-32, 2, 0);
    public Quaternion p1SpawnRotation = new Quaternion(0, 0, 0, 0);
    public Quaternion p2SpawnRotation = new Quaternion(0, 0, 0, 0);
    int i;
    public void Soldier()
    {
        if (SummonEnergy >= 3f)
        {
            if (isServer)
            {
                CmdP1soldier();
            }
            else
            {
                CmdP2Soldier();
            }
            SummonEnergy -= 3f;
        }
    }

    [Command]
    public void CmdP1soldier () {
        for (int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(SoldierProto, new Vector3(33, 2, 0), p1SpawnRotation);
            NetworkServer.Spawn(go);
        }
    }
    public void Archer()
    {
        if (SummonEnergy >= 3f)
        {
            if (isServer)
            {
                CmdP1archer();
            }
            else
            {
                CmdP2archer();
            }
            SummonEnergy -= 3f;
        }
    }
    [Command]
    public void CmdP1archer ()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject go = Instantiate(ArcherProto, new Vector3(33, 2, 0), p1SpawnRotation);
            NetworkServer.Spawn(go);
        }
    }
    public void Clubster()
    {
        if (SummonEnergy >= 4f)
        {
            if (isServer)
            {
                CmdP1clubster();
            }
            else
            {
                CmdP2clubster();
            }
            SummonEnergy -= 3f;
        }
    }
    [Command]
    public void CmdP1clubster ()
    {
        GameObject go = Instantiate(ClubsterProto, new Vector3(33, 2, 0), p1SpawnRotation);
        NetworkServer.Spawn(go);
    }
    [Command]
    public void CmdP2Soldier ()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(RedSoldierProto, new Vector3(-32, 2, 0), p2SpawnRotation);
            NetworkServer.Spawn(go);
        }
    }
    [Command]
    public void CmdP2archer()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject go = Instantiate(RedArcherProto, new Vector3(-32, 2, 0), p2SpawnRotation);
            NetworkServer.Spawn(go);
        }
    }
    [Command]
    public void CmdP2clubster ()
    {
        GameObject go = Instantiate(RedClubsterProto, new Vector3(-32, 2, 0), p2SpawnRotation);
        NetworkServer.Spawn(go);
    }
	
	void Update ()
    {
        if (SummonEnergy < 20f)
        {
            SummonEnergy += 0.5f * Time.deltaTime;
        }
	}

    public void TellCameraTop()
    {
        Camera camera = FindObjectOfType<Camera>();
        if (isServer)
        {
            camera.GetComponent<CameraMovement>().MoveToTop();
        }
        else
        {
            camera.GetComponent<CameraMovement>().P2MoveToTop();
        }
    }
    public void TellCameraSide ()
    {
        Camera camera = FindObjectOfType<Camera>();
        if (isServer)
        {
            camera.GetComponent<CameraMovement>().MoveToSide();
        }
        else
        {
            camera.GetComponent<CameraMovement>().P2MoveToSide();
        }
    }
}