using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D theObject) 
    {
        if (theObject.tag=="Player")
        {
            Debug.Log("Se muriooo");
            PlayerControler.compartido.KillPlayer();
        }
    }



}