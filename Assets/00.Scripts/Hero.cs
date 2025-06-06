using System.Collections;
using UnityEngine;

public class Hero : Character
{
    public float Attack_Range = 1.0f;
    public float Attack_Speed = 1.0f;
    public Monster target;
    public LayerMask enemyLayer;    

    private void Update()
    {
        CheckForEnemyInRange();
    }

    void CheckForEnemyInRange()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, Attack_Range, enemyLayer);
        Attack_Speed += Time.deltaTime;

        if(enemiesInRange.Length > 0)
        {
            target = enemiesInRange[0].GetComponent<Monster>();
            
            if(Attack_Speed >=1.0f)
            {
                Attack_Speed = 0.0f;
                AttackEnemy(target);
            }            
        }
        else
        {
            target = null;
        }        
    }


    void AttackEnemy(Monster enemy)
    {
        AnimatorChange("ATTACK", true);
        enemy.GetComponent<Monster>().GetDamage(30);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Attack_Range);
    }
}
