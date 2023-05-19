using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayAnimation : MonoBehaviour
{
    //AGAFEM ELS VALORS QUE NECESSITEM D'ALTRES SCRIPTS
    Animator _animation;

    [SerializeField]
    Movement movementito;

    [SerializeField]
    Salto saltote;


//_________________________________________________________________________________________________________________________________________________________________________________________//


    // Start is called before the first frame update
    void Start()
    {
        _animation = GetComponent<Animator>();
    }


//_________________________________________________________________________________________________________________________________________________________________________________________//


    public void setanimationmove(float speed) // agafo el valor de la velocitata del document de Movement i poso parametres de barrera per a la animació
    {
         _animation.SetFloat("VelX", Mathf.Clamp(speed,0, 4)); 

        if (movementito.Run() == true)
        {
            _animation.SetFloat("VelX", Mathf.Clamp(speed, 4.1f, 6.5f));
        }
    }


    public void setanimationjump(float speed) // agafo el valor de la velocitata del document de Salto i poso parametres de barrera per a la animació
    {      
        _animation.SetTrigger("Jump");
    }
}
