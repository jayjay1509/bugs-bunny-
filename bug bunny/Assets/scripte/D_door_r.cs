using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_door_r : MonoBehaviour
{
    private float rajoutz = 10f;
    private cooldwon cooldownManager;
    private playercontroller _control;
    
    private bool is_door;
    private int one_shot;
    
    void Start()
    {
        // Trouver le CooldownManager dans la scène
        
        cooldownManager = GameObject.FindObjectOfType<cooldwon>();
        _control = FindObjectOfType<playercontroller>();
        
        
        if (cooldownManager == null)
        {
            Debug.LogError("CooldownManager non trouvé dans la scène. Assurez-vous qu'il est attaché à un objet.");
        }
        // Vérifier si le CooldownManager a été trouvé
        if (_control == null)
        {
            Debug.LogError("_control non trouvé dans la scène. Assurez-vous qu'il est attaché à un objet.");
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.W) && cooldownManager.CanTeleport())
            {
                _control.D_tel_R = !_control.D_tel_R;
                cooldownManager.UpdateTeleportTime();
                
            }
            
        }
        
    }

}
