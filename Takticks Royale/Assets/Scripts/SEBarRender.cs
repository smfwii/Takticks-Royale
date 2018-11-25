using UnityEngine;
using UnityEngine.UI;

public class SEBarRender : MonoBehaviour
{
    public GameObject seholder;
    public Image thisimage;
    void Start()
    {
        //changing the position is now obsolete
        //transform.position = new Vector3(-650, 287, 0);
    }

    void Update()
    {
        if (FindObjectOfType<Spawnstuff>() != null)
        {
            //transform.position = new Vector3(seback.transform.position.x - 841 + seholder.GetComponent<Spawnstuff>().SummonEnergy * 35.3f, seback.transform.position.y, 0);
            thisimage.fillAmount = seholder.GetComponent<Spawnstuff>().SummonEnergy * 0.05f;
        }
    }
}
