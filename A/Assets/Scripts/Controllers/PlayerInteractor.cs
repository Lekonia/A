using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{

    public bool isHoldingSomething = false;
    public bool hasCollided = false;
    public Interactable interactable;
    public GameObject capsule;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Interactable"))
        {
            interactable = other.GetComponent<Interactable>();
            hasCollided = true;
        }
    }

    private void GetInput(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingSomething == false)
            {
                print("Input worked");
                interactable.AttachToPlayer();
                isHoldingSomething = true;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hasCollided)
        {
            if (isHoldingSomething == true)
            {
                capsule.AddComponent<Rigidbody2D>();
                print("Input worked");
                interactable.DettachToPlayer();
                isHoldingSomething = false;
                hasCollided = false;
            }
            else
            {
                interactable.AttachToPlayer();
                isHoldingSomething = true;
            }
        }
    }
}
