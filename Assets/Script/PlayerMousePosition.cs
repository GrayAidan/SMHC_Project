using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMousePosition : MonoBehaviour
{
    private Vector2 midpoint;
    private Vector2 mouseToPlayer;

    public float midPointNegation;

    public Camera cam;

    public Vector2 PlayerMovementVector()
    {
        Vector2 pmv = new Vector2(0,0);

        int horizontal6th = Screen.currentResolution.width / 6;
        if (Input.mousePosition.x < horizontal6th)
        {
            pmv.x = -3;
        }
        else if (Input.mousePosition.x > horizontal6th && Input.mousePosition.x < horizontal6th * 2)
        {
            pmv.x = -2;
        }
        else if (Input.mousePosition.x > horizontal6th * 2 && Input.mousePosition.x < horizontal6th * 3 - midPointNegation)
        {
            pmv.x = -1;
        }
        else if (Input.mousePosition.x > horizontal6th * 3 - midPointNegation && Input.mousePosition.x < horizontal6th * 3 + midPointNegation)
        {
            pmv.x = 0;
        }
        else if (Input.mousePosition.x > horizontal6th * 3 + midPointNegation && Input.mousePosition.x < horizontal6th * 4)
        {
            pmv.x = 1;
        }
        else if (Input.mousePosition.x > horizontal6th * 4 && Input.mousePosition.x < horizontal6th * 5)
        {
            pmv.x = 2;
        }
        else if (Input.mousePosition.x > horizontal6th * 5)
        {
            pmv.x = 3;
        }

        int vertical6th = Screen.currentResolution.height / 6;
        if (Input.mousePosition.y < vertical6th)
        {
            pmv.y = -3;
        }
        else if (Input.mousePosition.y > vertical6th && Input.mousePosition.y < vertical6th * 2)
        {
            pmv.y = -2;
        }
        else if (Input.mousePosition.y > vertical6th * 2 && Input.mousePosition.y < vertical6th * 3 - midPointNegation)
        {
            pmv.y = -1;
        }
        else if (Input.mousePosition.y > vertical6th * 3 - midPointNegation && Input.mousePosition.y < vertical6th * 3 + midPointNegation)
        {
            pmv.y = 0;
        }
        else if (Input.mousePosition.y > vertical6th * 3 + midPointNegation && Input.mousePosition.y < vertical6th * 4)
        {
            pmv.y = 1;
        }
        else if (Input.mousePosition.y > vertical6th * 4 && Input.mousePosition.y < vertical6th * 5)
        {
            pmv.y = 2;
        }
        else if (Input.mousePosition.y > vertical6th * 5)
        {
            pmv.y = 3;
        }

        return pmv;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        
        Gizmos.DrawLine(new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, 100), new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, -100));
        Gizmos.DrawLine(new Vector2(100, cam.ScreenToWorldPoint(Input.mousePosition).y), new Vector2(-100, cam.ScreenToWorldPoint(Input.mousePosition).y));

        //Horizontal
        int horizontal6th = Screen.currentResolution.width / 6;
        int vertical6th = Screen.currentResolution.height / 6;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th)).y), new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 5)).y));
        Gizmos.DrawLine(new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 5, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 5)).y), new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 5, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th)).y));
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 2, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 2)).y), new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 2, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 4)).y));
        Gizmos.DrawLine(new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 4, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 4)).y), new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 4, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 2)).y));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 3, 0)).x, 100), new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 3, 0)).x, -100));

        //Vertical
        Gizmos.color = Color.green;
        //Gizmos.DrawLine(new Vector2(100, cam.ScreenToWorldPoint(new Vector2(vertical6th, 0)).x), new Vector2(-100, cam.ScreenToWorldPoint(new Vector2(vertical6th, 0)).x));
        Gizmos.DrawLine(new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th)).y), new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 5, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th)).y));
        Gizmos.DrawLine(new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 5)).y), new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 5, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 5)).y));
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 4, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 2)).y), new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 2, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 2)).y));
        Gizmos.DrawLine(new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 4, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 4)).y), new Vector2(cam.ScreenToWorldPoint(new Vector2(horizontal6th * 2, 0)).x, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 4)).y));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(100, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 3)).y), new Vector2(-100, cam.ScreenToWorldPoint(new Vector2(0, vertical6th * 3)).y));
    }
}
