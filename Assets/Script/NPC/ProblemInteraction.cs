using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProblemInteraction : MonoBehaviour
{
    private ProblemWaypoint _pw;

    // Start is called before the first frame update
    void Start()
    {
        _pw = GetComponent<ProblemWaypoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_pw.distanceFromPlayer > 2)
        {
            _pw.img.transform.GetChild(0).gameObject.GetComponent<Text>().text = _pw.distanceFromPlayer.ToString();
        }
        else
        {
            _pw.img.transform.GetChild(0).gameObject.GetComponent<Text>().text = "!";
            InteractionCheck();
        }

    }

    public void InteractionCheck()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<NPCRespawn>().RespawnProblemNPC(false);
            StaticValues.score += 100;
        }
    }
}
