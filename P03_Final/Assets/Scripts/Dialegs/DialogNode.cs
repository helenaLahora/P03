using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDialogNode", menuName = "DialogSystem/DialogNode")]
public class DialogNode : ScriptableObject
{
    public string Speech;
    public List<DialogOptions> Options;
}


//ESTO SE TIENE QUE SABER DE MEMORIA PARA QUE LA LISTA DE OPCIONES APAREZCA
[System.Serializable]
public class DialogOptions
{
    public string Text;
    public DialogNode NextNode; // esta es la información que necesita para ir siguiendo las distintas rutas de las opciones

}
