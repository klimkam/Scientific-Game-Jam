using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 20;
    private bool hasFiredMoving = false;
    private bool hasFiredStopping = false;

    [SerializeField]
    Camera m_camera;

    private Vector3 m_motion;
    private Rigidbody m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        m_motion = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Jump"), Input.GetAxisRaw("Vertical"));
        m_motion = m_camera.transform.rotation * m_motion;
        m_rb.velocity = m_motion * m_speed;

        if (m_rb.velocity.magnitude > 0.01f)
        {
            if (!hasFiredMoving)
            {
                AkSoundEngine.PostEvent("AkE_PlayerMove", gameObject);
                hasFiredMoving = true;
            }
        }
        else
        {
            hasFiredMoving = false;
        }
        if (m_rb.velocity.magnitude < 0.01f)
        {
            if (!hasFiredStopping)
            {
                AkSoundEngine.PostEvent("AkE_PlayerStop", gameObject);
                hasFiredStopping = true;
            }
        }
        else
        {
            hasFiredStopping = false;
        }
    }
}
