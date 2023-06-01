using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{
    public Button buttonToEnable;
    public Button buttonToDisable;

    public void OnButtonClicked()
    {
        // Desactivar el botón y oscurecerlo
        buttonToEnable.interactable = true;
        buttonToDisable.interactable = false;

        // Aquí puedes agregar el código adicional que deseas ejecutar cuando se presione el botón
    }
}
