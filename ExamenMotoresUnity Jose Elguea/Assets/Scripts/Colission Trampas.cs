using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColissionTrampas : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "player")
        {
            other.gameObject.GetComponent<PlayerMov>().kill();
        }

    }
}
