using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Options : MonoBehaviour
{   
    public void FullScreen(bool FullScreen){
        Screen.fullScreen = FullScreen;
    }
    public void QualityLow(){
        Screen.SetResolution(1280,720,true);
    }
    public void QualityHigh(){
        Screen.SetResolution(1920,1080,true);
    }
}
