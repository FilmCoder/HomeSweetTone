using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnimationManager : MonoBehaviour
{
    private Animator animator;
    private Animator parent_animator;


    // Start is called before the first frame update
    void Start()
    {
        GameObject parent = transform.parent.gameObject;
        parent_animator = parent.GetComponent<Animator>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // parent animator deals with setting the position of the character,
        // and this objects animator deals with the "bounce" in the walk
        if(parent_animator.IsInTransition(0))
        {
            Debug.Log("WALKING");
            animator.SetBool("IsWalking", true);
        } else
        {
            Debug.Log("NOT WALKING");
            animator.SetBool("IsWalking", false);
        }
    }
}
