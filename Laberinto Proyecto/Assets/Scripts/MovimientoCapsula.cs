using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MovimientoCapsula : MonoBehaviour
{
    //Textos Relacionados Con el final y el inicio
    public GameObject textoInicio; 


    //Variables mov camara
    public Transform playerCamera = null; //Variable para poder asignar la camara en unity 

    float mouseSens = 3.0f;
    float cameraPitch = 0.0f; //Variable Base que indica que la camara empieza mirando al frente 

    bool lockCursor = true; //Variable de uso para bloquear el cursor


    /* he declarado estas 2 variables como p�blicas para que aparezcan en el inspector de Unity 
       y poder modificar la velocidad de avance y retroceso como la de rotaci�n de la capsula directamente desde el inspector. */
    public float velocidad = 3.0f;
    public float velocidadRotacion = 130.0f;
    float velocidadY = 0.0f; //Velocidad en eje Y para calcular gravedad
    float gravity = -13f;  //Valor para la gravedad

    // Declaro una variable privada para referenciar el componente characterController
    private CharacterController characterController;

    // Metodo Start se llama antes de cada frame
    void Start()
    {
        StartCoroutine(mostrarTexto(textoInicio)); //Activamos el texto de inicio al principio para simular el reinicio 

        // Obtenemos el componente CharacterController del objeto al que has a�adido este script
        characterController = GetComponent<CharacterController>();

        //Borramos el cursor del juego para que no moleste
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }

    // Metodo Update se llama una vez por frame
    void Update()
    {
        //Llamadas a los metodos que mueven al camara y el personaje
        UpdateMouseLook();
        movimiento();
    }


    void UpdateMouseLook()
    {

        //Eje X
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); //Recogemos las cordenadas del raton en un vector
        transform.Rotate(Vector3.up * mouseDelta.x * mouseSens);// Rotamos el valor de la camara en el valor de las X y ajustada por la sens del raton asignada

        //Eje y
        cameraPitch -= mouseDelta.y * mouseSens; // Se resta por la distribucion del valor en el eje de las Y( - Arriba, + Abajo)
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f); //Se limita el campo de rotacion a 180 grados para que la camara no se salga de rango
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;// Asinamos el valor de las Y en el Vector3(Que es el de las Y)
    }

    void movimiento()
    {

        /* Obtenemos el valor del eje horizontal y lo multiplicamos por la variable velocidadRotacion
           luego lo multiplico por Time.deltaTime, Time.deltaTime lo que hace es que se movera a una velocidad concreta 
           independientemente de los FPS que se ejecute el juego en diferentes maquinas. */
        float horizontal = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;


        /* Obtenemos el valor del eje vertical y lo multiplicamos por la variable velocidad
           luego lo multiplico por Time.deltaTime, Time.deltaTime lo que hace es que se movera a una velocidad concreta 
           independientemente de los FPS que se ejecute el juego en diferentes maquinas. */
        float vertical = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;

        if (characterController.isGrounded)
        { //Si toca el suelo la velocidadY siempre es cero
            velocidadY = 0f;
        }
        velocidadY += gravity * Time.deltaTime; //Aplicamos la gravedad ajustada por el tiempo del juego

        Vector2 velocidadTotal = new Vector2(horizontal, vertical); //Juntamos las dos variables en un vector para simplificar

        //Creamos un nuevo vector donde almacenamos el movimiento en los dos ejes teniendo en cuenta la gravedad
        Vector3 MoverAdelante = transform.TransformDirection(Vector3.forward * velocidadTotal.y + Vector3.right * velocidadTotal.x) + Vector3.up * velocidadY; 

        // Mueve la capsula utilizando el characterController
        characterController.Move(MoverAdelante);
    }


    IEnumerator mostrarTexto(GameObject textoInicio) //Mostramos el texto con delay
    {
        textoInicio.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        textoInicio.SetActive(false);

    }
}
