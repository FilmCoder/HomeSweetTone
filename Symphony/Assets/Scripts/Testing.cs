using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        
    }

    void Update()
    {   
        // toggle inside/outside animation state
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("IsInside", !animator.GetBool("IsInside"));
            print("space key was pressed");
        }
    }
}
