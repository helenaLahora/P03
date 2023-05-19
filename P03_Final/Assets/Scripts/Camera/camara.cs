using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class camara : MonoBehaviour
{
    // ES CREEN TOTS ELS VALORS NECESSARIS PER A QUE APAREGUIN EN PANTALLA I ES PUGUIN MODIFICAR
    public Transform player; //referencia del objecte d'escena que identifiquem com jugador.
    
    public float mouseSensitivity = 2f; // directament proporcional a la sensibilitat que volem que tingui el ratol� per more la camara.
    
    float cameraVerticalRotation = 0f; //valor incial �s 0 perque el personatge miri recte al inciar el joc.
    
    bool toggleCamera = false;

    private float ScrollSpeed = 10;


    Vector3 posicionCamara = Vector3.zero;
    Vector3 rotacion = new Vector3(20, 0, 0);

    //AGAFEM ELS VALORS QUE NECESSITEM D'ALTRES SCRIPTS
    Camera ZoomCamera;

    [SerializeField]
    InputSystem input;


//_________________________________________________________________________________________________________________________________________________________________________________________//


    // Start is called before the first frame update
    void Start()
    {
        // Bloquejar i amagar el cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 rotacion = transform.localEulerAngles;

        ZoomCamera = Camera.main;

    }


    // Update is called once per frame
    void Update()
    {
        if (Camera2() == true)
        {
            //si clica C se cambia el valor
            toggleCamera = !toggleCamera;
        }

        if (toggleCamera)
        {
            //primera persona
            rotateFirst();
            firstPOV();
            zoom();
        }

        else
        {
            transform.localEulerAngles = rotacion;
            // tercera persona
            thirdPOV();
            zoom();
        }
    }


//_________________________________________________________________________________________________________________________________________________________________________________________//


    private bool Camera2()
    {
        return input.Controles_C; // S'ha apretat la tecla C? Doncs llavors correrà
                                  // Control adquirit del SCRIPT InputSystem
    }


//_________________________________________________________________________________________________________________________________________________________________________________________//


    void rotateFirst()
    {
        // REGISTRAR INFORMACI� D'INPUT
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity; // registra el valor de l'eix x del ratolí, multiplicat per la sensibilitat a la variable.
        float inputY = Input.GetAxis("Mouse Y"); // igual a l'anterior amb l'eix Y

        // ROTAR LA C�MARA EN L'EIX X (moviment vertical)
        cameraVerticalRotation -= inputY;

        // s'utilitza - i no + perque quan mous el ratolí amunt obtens un valor positiu, pero per rotar la càmara amunt la rotació ha de ser negativa.
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        
        // limita el gir de la c�mara a -90 graus i 90 graus
        transform.localRotation = Quaternion.Euler(cameraVerticalRotation, 0f, 0f);

        // ROTAR LA CÀMARA I EL JUGADOR EN L'EIX Y (moviment horitzontal)
        // rotem la camara i el jugador
        player.Rotate(Vector3.up * inputX);
        transform.rotation = Quaternion.Euler(cameraVerticalRotation, player.eulerAngles.y, 0f);
    }


//_________________________________________________________________________________________________________________________________________________________________________________________//


    void firstPOV()
    {
        // moure càmara a posició del player
        posicionCamara = new Vector3(player.transform.position.x, player.transform.position.y + 3.2f, player.transform.position.z + 0.4f);
        transform.position = posicionCamara;

        //modificar la culling mask per no mostrar el personatge
        this.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Ground");
    }

    void thirdPOV()
    {
        // mover camara a posicion del player
        posicionCamara = new Vector3(player.transform.position.x, player.transform.position.y + 4.5f, player.transform.position.z - 6f);
        transform.position = posicionCamara;

        //modificar la culling mask per no mostrar el personatge
        this.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Ground", "Player");
    }


//_________________________________________________________________________________________________________________________________________________________________________________________//


    void zoom()
    {
        ZoomCamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
    }


}
