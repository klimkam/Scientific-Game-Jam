using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 20;
    private bool hasFiredMoving = false;
    private bool hasFiredStopping = false;


    // public float Speed {
    //     get{ return m_speed; }
    //     set{
    //         if (value > 10 && !hasFiredMoving) {
    //             hasFiredMoving = true;
    //             AkSoundEngine.PostEvent("AkE_PlayerMove", gameObject);
    //         }
    //         if (value < 5 && !hasFiredStopping)
    //         {
    //             hasFiredStopping = true;
    //             AkSoundEngine.PostEvent("AkE_PlayerStop", gameObject);
    //         }
    //         m_speed = value;
    //     }
    // }

    public bool FiredMoving{
        get{return hasFiredMoving;}
        set{
            if (!value) {
                AkSoundEngine.PostEvent("AkE_PlayerMove", gameObject);
            }
            // if (!value)
            // {
            //     AkSoundEngine.PostEvent("AkE_PlayerStop", gameObject);
            // }
            hasFiredMoving = value;
        }
    }
        public bool FiredStopping{
        get{return hasFiredStopping;}
        set{
            if (!value) {
                AkSoundEngine.PostEvent("AkE_PlayerStop", gameObject);
            }
            // if (!value)
            // {
            //     AkSoundEngine.PostEvent("AkE_PlayerStop", gameObject);
            // }
            hasFiredStopping = value;
        }
    }

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

        hasFiredMoving = m_rb.velocity.magnitude > 0.01f;
        hasFiredStopping = m_rb.velocity.magnitude < 0.01f;
    }
}
