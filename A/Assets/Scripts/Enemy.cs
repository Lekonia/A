using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private float dazedTime;
    public float startDazedTime;

    //private Animator anim;
    //public GameObject bloodEffect;

    void Start()
    {
        //anim.GetComponent<Animator>();
        //anim.SetBool("isRunning", true);
    }

    void Update()
    {
        if (dazedTime <= 0)
        {
            speed = 5;
        }

        else
        {
            speed = 0;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        // Play hurt sound
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage Taken");
    }
}
