using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using TMPro;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public SpriteRenderer _sr;
    [SerializeField] private float moventspeed = 5000f;
    [SerializeField] private float jumspeed = 10000f;
    public bool run_ok = true;

    public bool _tel_L = false;
    public bool _esc_L = false;
    public bool _esc_R = false;
    public bool _tel_R = false;
    public bool D_tel_L = false;
    public bool D_esc_L = false;
    public bool D_esc_R = false;
    public bool D_tel_R = false;
    public bool _mov = false;
   
    

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator _anim;
    private BoxCollider2D _box;
    private  grounded_detector _is_grounded;
    [SerializeField]
    public Vector3 deplacement_animation;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent <SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
        _is_grounded = GetComponentInChildren<grounded_detector>();
    }

    void Update()
    {
        if (_esc_L)
        {
            _esc_L = false;
            StartCoroutine(BlinkObject());
            _anim.SetTrigger("esc_l");
        }
        if (_esc_R)
        {
            _esc_R = false;
            StartCoroutine(BlinkObject());
            _anim.SetTrigger("esc_r");
        }
        if (_tel_L)
        {
            _tel_L = false;
            sr.sortingOrder = 1;
            StartCoroutine(BlinkObject());
            _anim.SetTrigger("test");
            Debug.Log("depuis de l'animation");
        }
        if (_tel_R)
        {
            _tel_R = false;
            sr.sortingOrder = 1;
            StartCoroutine(BlinkObject());
            _anim.SetTrigger("door_r");
            Debug.Log("depuis de l'animation");
        }
        
        if (D_esc_L)
        {
            D_esc_L = false;
            StartCoroutine(BlinkObject());
            _anim.SetTrigger("D_esc_l");
        }
        if (D_esc_R)
        {
            D_esc_R = false;
            StartCoroutine(BlinkObject());
            _anim.SetTrigger("D_esc_r");
        }
        if (D_tel_L)
        {
            D_tel_L = false;
            sr.sortingOrder = 1;
            StartCoroutine(BlinkObject());
            _anim.SetTrigger("D_door_l");
            Debug.Log("depuis de l'animation");
        }
        if (D_tel_R)
        {
            D_tel_R = false;
            sr.sortingOrder = 1;
            StartCoroutine(BlinkObject());
            _anim.SetTrigger("D_door_r");
            Debug.Log("depuis de l'animation");
        }
        
    }
    void FixedUpdate()
    {
        
        
        if (_mov)
        {
            Debug.Log("tu est bloque ");
            _box.isTrigger = true;
            rb.simulated = false;
            transform.position += deplacement_animation;
        }

        else
        {
            _box.isTrigger = false;
            rb.simulated = true;
            sr.sortingOrder = 3;
            Debug.Log("je peu marche ");
            
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
    IEnumerator BlinkObject()
    {
            _mov = true;
            Debug.Log("depuis de couroutine");
            
            yield return new WaitForSeconds(1.0f);


            _mov = false;
            Debug.Log("fin de couroutine");
            
        
    }
    
}
