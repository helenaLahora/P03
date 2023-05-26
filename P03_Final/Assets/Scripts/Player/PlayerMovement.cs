using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 raw_movement;
    private CharacterController Cc;
    public Camera cam;
    private Vector3 movement;
    private float verticalSpeed;
    private float gravity = -20f;
    public float JumpForce = 10f;
    [HideInInspector] public bool menu = false;

    public float Controles_H;
    public float Controles_V;
    public bool Controles_J;

    private Coroutine speedBoostCoroutine; // Referencia al coroutine de aumento de velocidad
    private float baseSpeed; // Velocidad base del jugador
    private float currentSpeed; // Velocidad actual del jugador
    public float speedBoostDuration = 5f; // Duración del aumento de velocidad
    private float speedModifier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Cc = GetComponent<CharacterController>();

        baseSpeed = speedModifier;
        currentSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        verticalSpeed += gravity * Time.deltaTime;
        //Debug.Log(Cc.isGrounded);
        
        Movement();
        Salto(Controles_J);
        

        //Debug.Log(EventHandler.Variables[Variable.collectedObjects]);

        //ApplyGravity();

        //Debug.Log("Velocidad del jugador: " + speedModifier);
    }

    void LateUpdate() // Es fa desprès del Update (és una acció que es realitza just desprès del Update normal)
    {
        Controles_J = false; // Li dius que no li estas donant a la tecla espai, que constantment està en FALSE fins que prems la tecla space i es posa TRUE
    }

    public void OnMove(InputValue CONTROLES) //OnMove --> agafa el input de SystemInput pel moviment
                                              //InputValue --> agafa el valor que m'interessa i li poso el nom que vull (CONTROLES)
    {
        Controles_H = CONTROLES.Get<Vector2>().x; //Li assigno un nombre al valor que he agafat per no predre'l i el transformo en un Vector2 
        Controles_V = CONTROLES.Get<Vector2>().y;
    }

    public void Movement()
    {
        
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        movement = forward * Controles_V * speed + right * Controles_H * speed;
        //movement = new Vector3(raw_movement.x,0,raw_movement.y);
        movement.y = verticalSpeed;

        Cc.Move(movement * Time.deltaTime * speedModifier);
        if (movement.x != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(movement.x, 0,  movement.z));
        }
        if (Cc.isGrounded)
        {
            verticalSpeed = 0f;
            movement.y = 0f;
        }
    }

    void ApplyGravity()
    {
        if (!Cc.isGrounded)
        {
            gravity = -9.8f;
            movement.y += gravity;
        }
        else
        {
            gravity = 0;
        }
    }


    public void OnJump() 
    { 
        Controles_J = true;
        Salto(Controles_J);

    }


    public void Salto(bool Controles_J)
    {
        if (Cc.isGrounded)
        {
            verticalSpeed += JumpForce;
        }
    }





    // Método para aumentar la velocidad de movimiento
    public void IncreaseSpeed(float amount)
    {
        if (speedBoostCoroutine != null)
        {
            StopCoroutine(speedBoostCoroutine); // Detener el coroutine anterior si existe
        }

        speedModifier = baseSpeed + amount;
        speedBoostCoroutine = StartCoroutine(ResetSpeedAfterDelay(speedBoostDuration));
    }

    // Método para restablecer la velocidad de movimiento
    public void ResetSpeed()
    {
        speedModifier = baseSpeed;
        if (speedBoostCoroutine != null)
        {
            StopCoroutine(speedBoostCoroutine); // Detener el coroutine anterior si existe
        }
    }

    // Coroutine para restablecer la velocidad después de un retraso
    private IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetSpeed();
    }
}