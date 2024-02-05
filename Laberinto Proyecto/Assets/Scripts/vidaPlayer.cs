using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class vidaPlayer : MonoBehaviour
{
    public float vidaMax = 4.0f; //Vida del Jugador se mueve de 4 a 0 en reducciones de 1

    public float vida = 4.0f; //Vida actual

    public Image barra; //Imagen de la barra

    public void reducirVida(float danio) //Funcion para quitar una vida determinada al jugador en escala a la vida maxma
    {
        vida -= danio;
        barra.fillAmount = vida / vidaMax; //Modifico el valor de fill de la barra de manera que se reduce en cuartos
        if( vida <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
