using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float flightSpeed;
    private float gravityScale;

    private PlayerMousePosition _pmp;
    private Rigidbody2D _rb;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        _pmp = GetComponent<PlayerMousePosition>();
        _rb = GetComponent<Rigidbody2D>();
        gravityScale = _rb.gravityScale;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            _rb.velocity = movement * flightSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Flying();
        }
        else
        {
            Falling();
        }
    }

    private void Flying()
    {
        movement = _pmp.PlayerMovementVector();
        _rb.gravityScale = 0;

        Vector2 vectorFromPlayer = _pmp.cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rad = Mathf.Atan2(vectorFromPlayer.y, vectorFromPlayer.x);
        float angle = rad * Mathf.Rad2Deg;

        //if this angle is NEGFATIVE, flip the super hero so he isnt flying upside down
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, angle - 90);
    }

    private void Falling()
    {
        movement = new Vector2(0, 0);
        _rb.gravityScale = gravityScale;
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 0);
    }
}
