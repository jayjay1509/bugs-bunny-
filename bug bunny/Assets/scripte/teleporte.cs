using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class teleporte : MonoBehaviour
{
    public Transform destination;
    public Transform _target;
    //private float rajoutY = 1f;
    private float rajoutz = 10f;
    private cooldwon cooldownManager;
    
    void Start()
    {
        // Trouver le CooldownManager dans la scène
        cooldownManager = GameObject.FindObjectOfType<cooldwon>();
        
        // Vérifier si le CooldownManager a été trouvé
        if (cooldownManager == null)
        {
            Debug.LogError("CooldownManager non trouvé dans la scène. Assurez-vous qu'il est attaché à un objet.");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.W) && cooldownManager.CanTeleport())
            {
                Vector3 newPosition = new Vector3(destination.position.x, destination.position.y , destination.position.z + rajoutz);
                _target.position = newPosition;
                Debug.Log("Tu as appuyé sur W. Téléportation effectuée.");

                cooldownManager.UpdateTeleportTime();
            }
            Debug.Log("J'ai un joueur dans la zone.");
        }
        Debug.Log("Tu es dans la zone de téléportation.");
    }
}

    

