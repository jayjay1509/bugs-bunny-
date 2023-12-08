using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public SpriteRenderer _sr;
    [SerializeField] private float moventspeed = 5000f;
    [SerializeField] private float jumspeed = 10000f;
    public bool run_ok = true;

    private Rigidbody2D rb;
    private Animator _anim;
    private  grounded_detector _is_grounded;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _is_grounded = GetComponentInChildren<grounded_detector>();
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
       
        
        if (rb.velocity.x <= -0.1f)
        {
            _sr.flipX = false;
        }
        else if (rb.velocity.x >= 0.1f)
        {
            _sr.flipX = true;
        }

        if (_is_grounded.is_grounded)
        {
            rb.velocityX = 0;
            _anim.speed = 0;
        }
        else
        {
            _anim.speed = 1;
            rb.velocityX = (Input.GetAxis("Horizontal") * Time.deltaTime * moventspeed);
        
            if (Mathf.Abs(Input.GetAxis("Horizontal")) >= 0.01f)
            {
                _anim.SetBool("iswalking", true);
            }
            else
            {
                _anim.SetBool("iswalking", false);
            }
        }

        
    }
}
