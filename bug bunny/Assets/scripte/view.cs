using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view : MonoBehaviour
{
    [SerializeField]
    private int distance_gauche = -7;
    [SerializeField]
    private int distance_droite = 12;
    
    
    public Transform joueur;  

    void Update()
    {
            Vector3 newPosition = transform.position;

            if (joueur.position.x  <= distance_gauche )
            {
                newPosition.x = distance_gauche;
                //Debug.Log( "tu est a gauche "+joueur.position.x);
            }

            else if (joueur.position.x >= distance_droite)
            {
                newPosition.x = distance_droite;
                //Debug.Log( "tu est a droite "+joueur.position.x);
            }
            else
            {
                newPosition.x  = joueur.position.x ;
                
                //Debug.Log( "tu est au centre "+joueur.position.x);
            }
            
            transform.position = newPosition;
    }
     
}
