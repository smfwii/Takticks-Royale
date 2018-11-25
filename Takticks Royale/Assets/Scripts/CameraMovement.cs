using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    Vector3 p1topPos = new Vector3(34.6f, 44.4f, 0);
    Vector3 p1topRot = new Vector3(60, 270, 0);
    Vector3 p1sidePos = new Vector3(0, 26.6f, 46.7f);
    Vector3 p1sideRot = new Vector3(10, 180, 0);
    Vector3 p2topPos = new Vector3(-34.6f, 44.4f, 0);
    Vector3 p2topRot = new Vector3(60, 90, 0);
    Vector3 p2sidePos = new Vector3(0, 26.6f, -46.7f);
    Vector3 p2sideRot = new Vector3(10, 0, 0);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Mouse ScrollWheel") * -4, 0, 0, Space.World);
        if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
        {
            if (Input.GetKey("w"))
            {
                transform.Rotate(1, 0, 0);
            }
            if (Input.GetKey("s"))
            {
                transform.Rotate(-1, 0, 0);
            }
        }
        else
        {
            if (Input.GetKey("w"))
            {
                transform.Translate(0, 0, 1, Space.Self);
            }
            if (Input.GetKey("s"))
            {
                transform.Translate(0, 0, -1, Space.Self);
            }

        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -1, 0, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 1, 0, Space.World);
        }

    }
    public void MoveToTop ()
    {
        transform.position = p1topPos;
        transform.rotation = Quaternion.Euler(p1topRot);
    }
    public void MoveToSide ()
    {
        transform.position = p1sidePos;
        transform.rotation = Quaternion.Euler(p1sideRot);
    }
    public void P2MoveToTop ()
    {
        transform.position = p2topPos;
        transform.rotation = Quaternion.Euler(p2topRot);
    }
    public void P2MoveToSide()
    {
        transform.position = p2sidePos;
        transform.rotation = Quaternion.Euler(p2sideRot);
    }
}
