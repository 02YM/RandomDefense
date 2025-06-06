using System.Collections;
using UnityEngine;

public class Monster : Character
{
    
    [SerializeField]
    private float moveSpeed = 2f;

    public float HP = 100;

    int targetValue = 0;
    private bool isDead = false;

    public override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (isDead) return;
        transform.position = Vector2.MoveTowards(transform.position, SpawnManager.move_list[targetValue], Time.deltaTime * moveSpeed);

        if(Vector2.Distance(transform.position , SpawnManager.move_list[targetValue]) <= 0.0f)
        {
            targetValue++;
            renderer.flipX = targetValue>=3 ? true : false;

            if(targetValue >= 4)
                targetValue = 0;
        }
    }

    public void GetDamage(int dmg)
    {
        if (isDead) return;

        HP -= dmg;
        if(HP <= 0)
        {
            isDead = true;
            gameObject.layer = LayerMask.NameToLayer("Default");
            AnimatorChange("DEAD", true);
            StartCoroutine(Dead_Coroutine());
        }
    }

    IEnumerator Dead_Coroutine()
    {
        float Alpha = 1.0f;

        while(renderer.color.a > 0.0f)
        {
            Alpha -= Time.deltaTime;
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, Alpha);

            yield return null;
        }

        Destroy(this.gameObject);
    }
}
