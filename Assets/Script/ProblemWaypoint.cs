using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProblemWaypoint : MonoBehaviour
{
    public Image img;
    public Transform npc;
    public Transform player;
    [HideInInspector]
    public int distanceFromPlayer;

    [HideInInspector]
    public int timer;

    private void Start()
    {
        InvokeRepeating("AddTime", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(new Vector2(npc.position.x, npc.position.y + 3.5f));

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        img.transform.position = pos;

        distanceFromPlayer = (int)Vector2.Distance(player.position, npc.position);

        WaypointTimer();
    }

    public void WaypointTimer()
    {
        if(timer < 10)
        {
            img.color = Color.green;
        }
        else if(timer > 10 && timer < 20)
        {
            img.color = Color.yellow;
        }
        else if(timer > 20 && timer < 30)
        {
            img.color = Color.red;
        }
        else if (timer >= 30)
        {
            GetComponent<NPCRespawn>().RespawnProblemNPC(true);
            timer = 0;
        }
    }

    public void AddTime()
    {
        timer++;
    }
}
