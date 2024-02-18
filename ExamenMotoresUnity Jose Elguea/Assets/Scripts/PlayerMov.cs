using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class PlayerMov : MonoBehaviour
{

    public GameObject deadText;

    CharacterController player;
    public Transform playerCamara;

    float walkspeed = 4f;
    float velocityY = 0f;
    float gravity = -9.81f;
    float jumpHeight = 8f;

    float camaraPitch = 0f;
    float camaraSense = 3f;

    bool disable = false;

    bool ice = false;

    float smoothTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!disable)
        {
            camaraMov();
            playerMov();
        }

    }

    void camaraMov()
    {
        Vector2 camaraSpeed = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.Rotate(Vector3.up * camaraSpeed.x * camaraSense);

        camaraPitch -= camaraSpeed.y * camaraSense;
        camaraPitch = Mathf.Clamp(camaraPitch, -90f, 90f);
        playerCamara.localEulerAngles = (Vector3.right * camaraPitch);

    }

    void playerMov()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        dir.Normalize();



        velocityY += gravity * Time.deltaTime;

        if(player.isGrounded)
        {
            velocityY = -0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                velocityY = jumpHeight;
            }
        }
        /* Explicacion de que intento programar aqui en el word del examen
        if (ice){

            Vector2 iceDir = Vector2.SmoothDamp(dir, , smoothTime);

            Vector3 velocity = (transform.forward * iceDir.y + transform.right * iceDir.x) * walkspeed + Vector3.up * velocityY;

            player.Move(velocity * Time.deltaTime);

        }
        else
        {
            Vector3 velocity = (transform.forward * dir.y + transform.right * dir.x) * walkspeed + Vector3.up * velocityY;

            player.Move(velocity * Time.deltaTime);
        }
        */
        Vector3 velocity = (transform.forward * dir.y + transform.right * dir.x) * walkspeed + Vector3.up * velocityY;

        player.Move(velocity * Time.deltaTime);

    }

    public void kill()
    {
        StartCoroutine(killDelay()); 
    }



    IEnumerator killDelay()
    {
        disable = true;
        deadText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        player.transform.position = Vector3.up;
        yield return new WaitForSeconds(0.5f);
        disable = false;
        deadText.SetActive(false);
        camaraPitch = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "ice")
        {
            ice = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ice")
        {
            ice = false;
        }
    }

}
