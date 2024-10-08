using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    public float damage = 3;

    public enum AttackDirection
    {
        left, right
    }

    public AttackDirection attackDirection;

    Vector2 rightAttackOffset;
    public Collider2D swordCollision;

    private void Start()
    {
        // swordCollision = GetComponent<Collider2D>();
        rightAttackOffset = transform.position;
    }



    public void AttackRight()
    {
        swordCollision.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft()
    {
        swordCollision.enabled = true;
        transform.localPosition = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack()
    {
        swordCollision.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Health -= damage;
            }
        }
    }
}
