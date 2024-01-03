using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables expecificadas public se muestran dentro del HUD de Unity


    public Transform playerCamera = null; //Variable para poder asignar la camara en unity 
    float mouseSens = 3.0f; //Sensibilidad del raton para ajustar el movimiento de la camara
    float cameraPitch = 0.0f; //Variable Base que indica que la camara empieza mirando al frente 
    bool lockCursor = true; //Variable de uso para bloquear el cursor
    public float walkSpeed = 6.0f; // Velocidad usada para calcular el movimiento
    CharacterController controller = null;//Variable para asignar el CharacterController del player

    float moveSmoothTime = 0.15f; //Variable usada para el tiempo para hacer el movimiento más natural

    //Vectores Usados en la funcion de SmoothDamp
    Vector2 currentDir = Vector2.zero; // Vector de direcion inicial
    Vector2 currentDirNew = Vector2.zero;// Vector de direcion a donde queremos ir
    //Vector2.zero = (0,0)


    // Start is called before the first frame update
    void Start()
    {
        //Asignamos la variable controller a;l Controller del Player
        controller = GetComponent<CharacterController>();

        //Borramos el cursor del juego para que no moleste
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }

    //Metodo de Movimiento de Camara
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

    //Metodo de Movimiento del personaje
    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //Tomamos el input de los Axis del juegador
        targetDir.Normalize(); //Normalizamos el Vector para el movimiento en diagonal

        //SmoothDamp es un metodo que nos sirve para aproximar en un *tiempo* el valor de un vector1 a un vector2 usando otro vector como referencia
        //Vector2.SmoothDamp(Vector2 current, Vector2 target, ref Vector2 , float time,float maxspeed*esta ultima no se usa en este caso*)
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirNew, moveSmoothTime);

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed; //Creamos una velocidad de movimiento usando el vector de imputs y el movimiento actual teniendo en cuanta la walkSpeed
        controller.Move(velocity * Time.deltaTime); //Movemos el personaje usando una velocidad y el tiempo del juego
    }
}
