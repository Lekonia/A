using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttackl;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    //public Animator camAnim;
    //public Animator playerAnim;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            // Then you can attack
            if (Input.GetKey(KeyCode.Space))
            {
                //camAnim.SetTrigger("shake");
                //playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }

            timeBtwAttack = startTimeBtwAttackl;
        }

        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
