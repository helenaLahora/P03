using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara_minimapa : MonoBehaviour
{
    // ES CREEN TOTS ELS VALORS NECESSARIS PER A QUE APAREGUIN EN PANTALLA I ES PUGUIN MODIFICAR
    public Transform player; //referencia de l'objecte d'escena que identifiquem com jugador.
    
    Vector3 posicionPlayer = Vector3.zero;


//_________________________________________________________________________________________________________________________________________________________________________________________//


    // Update is called once per frame
    void Update()
    {
        posicionPlayer = new Vector3(player.transform.position.x, player.transform.position.y + 15, player.transform.position.z);
        transform.position = posicionPlayer;
    }
}
