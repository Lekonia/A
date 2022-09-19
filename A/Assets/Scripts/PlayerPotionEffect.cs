using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPotionEffect : MonoBehaviour
{
    public GameObject pPE;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Potion"))
        {
            Debug.Log("I have been hit with a potion!");
            pPE.SetActive(true);
        }
    }
}
