using UnityEngine;

public class Character : MonoBehaviour
{
    protected Animator animator;
    protected SpriteRenderer renderer;

    public virtual void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        renderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    protected void AnimatorChange(string temp, bool Trigger)
    {
        if(Trigger)
        {
            animator.SetTrigger(temp);
        }
        else
        {
            animator.SetBool(temp, true);
        }
    }
}
