using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("El objeto " + other.gameObject.name + " ha entrado en el área de colisión.");
    }
}