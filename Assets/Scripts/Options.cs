using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Options : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public void FullScreen(bool FullScreen){
        Screen.fullScreen = FullScreen;
    }
    public void OnResolutionChanged(int index)
    {
        // Obtener la resolución seleccionada del Dropdown
        Resolution[] resolutions = Screen.resolutions;
        Resolution selectedResolution = resolutions[index];

        // Aplicar la resolución seleccionada
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
    }
}
