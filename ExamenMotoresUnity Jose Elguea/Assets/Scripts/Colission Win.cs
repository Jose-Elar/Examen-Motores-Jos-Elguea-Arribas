using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColissionWin : MonoBehaviour
{
    public GameObject winText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            winText.SetActive(true);
        }
    }
}
