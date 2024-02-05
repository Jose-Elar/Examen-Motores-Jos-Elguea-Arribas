using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger4 : MonoBehaviour
{
    public float DistaciaMov = 1f; // La distancia que se mover�n los objetos
    public float velocidadMov = 0.5f; // La velocidad de movimiento
    private bool SiMovido = false; // Controla si el movimiento ya ocurri�

    // Comprobar si el jugador ha entrado en el trigger a trav�s del tag "Player" y movera los objetos que tengan el tag "mover"
    // y a trav�s de SiMovido guardaremos si ya se ha movido la pared u objetos para que no se muevan otra vez si entras otra vez en el trigger

    private void OnTriggerEnter(Collider other)
    {
        if (!SiMovido && other.CompareTag("Player")) // Comprobar si el objeto que entr� es el jugador
        {
            GameObject[] objectsToMove = GameObject.FindGameObjectsWithTag("mover_pre");
            foreach (GameObject obj in objectsToMove)
            {
                obj.gameObject.tag = "mover"; //Cambiamos el tag de los objetos que se mueven para que dañen al jugador
                StartCoroutine(MoveObject(obj));
            }
            SiMovido = true; // Marcar que el movimiento ya ha ocurrido
        }
    }

    private IEnumerator MoveObject(GameObject obj)
    {
        Vector3 startPosition = obj.transform.position;
        Vector3 endPosition = startPosition + Vector3.back * DistaciaMov;

        float elapsedTime = 0;
        while (elapsedTime < DistaciaMov / velocidadMov)
        {
            obj.transform.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime * velocidadMov) / DistaciaMov);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = endPosition;
    }
}
