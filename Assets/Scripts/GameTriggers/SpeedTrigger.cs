using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D theObject)
    {
        if (theObject.tag == "Player")
        {
            PlayerControler.compartido.SpeedPlayer();
        }
    }

}
