using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeBar : MonoBehaviour
{
    public Image Life;
    public float ActualLife;
    public float MaxLife;
    void Update()
    {
        Life.fillAmount=ActualLife/MaxLife;
    }
}
