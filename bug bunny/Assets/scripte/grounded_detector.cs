using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded_detector : MonoBehaviour
{
    private Collider2D _collider2D;
    public bool is_grounded;
    
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("level"))
        {
            is_grounded = true;
            Debug.Log("il ne touche plus ");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("level"))
        {
            is_grounded = false;
            Debug.Log("il  touche  ");
        }
    }
}
