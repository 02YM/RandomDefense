using UnityEngine;

public class Monster : Character
{
    
    [SerializeField]
    private float moveSpeed = 2f;

    int targetValue = 0;

    public override void Start()
    {
        base.Start();
    }

    private void Update()
    {        
        transform.position = Vector2.MoveTowards(transform.position, SpawnManager.move_list[targetValue], Time.deltaTime * moveSpeed);

        if(Vector2.Distance(transform.position , SpawnManager.move_list[targetValue]) <= 0.0f)
        {
            targetValue++;
            renderer.flipX = targetValue>=3 ? true : false;

            if(targetValue >= 4)
                targetValue = 0;
        }
    }
}
