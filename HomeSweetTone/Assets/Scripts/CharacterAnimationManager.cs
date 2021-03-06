﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameController;


public class CharacterAnimationManager : MonoBehaviour
{
    public Animator girlAnimator;
    public Animator catAnimator;
    public Animator ladyAnimator;
    public Animator manAnimator;
    public Animator catParent;

    private Animator GetAnimator(CHARACTER character)
    {
        switch(character)
        {
            case CHARACTER.GIRL:
                return girlAnimator;
            case CHARACTER.CAT:
                return catAnimator;
            case CHARACTER.LADY:
                return ladyAnimator;
            default:
                return manAnimator;
        }
    }

    public void Leave(CHARACTER character)
    {
        Animator animator = GetAnimator(character);
        animator.SetBool("Leaving", true);
        animator.SetBool("Entering", false);
    }

    public void Enter(CHARACTER character)
    {
        Animator animator = GetAnimator(character);
        animator.SetBool("Leaving", false);
        animator.SetBool("Entering", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        // For testing purposes only.
        //StartCoroutine(DoStuff());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void BounceCat() {
        catAnimator.SetBool("Bouncing", true);
    }
}
