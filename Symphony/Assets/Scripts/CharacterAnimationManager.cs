using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationManager : MonoBehaviour
{
    public Animator girlAnimator;
    public Animator catAnimator;
    public Animator ladyAnimator;
    public Animator manAnimator;

    public enum CHARACTER
    {
        GIRL = 0,
        CAT = 1,
        LADY = 2,
        MAN = 3,
        PLAYER = 5
    }

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
        StartCoroutine(DoStuff());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DoStuff()
    {
        yield return new WaitForSeconds(3);
        Leave(CHARACTER.LADY);
        yield return new WaitForSeconds(6);
        Enter(CHARACTER.LADY);

        yield return new WaitForSeconds(3);
        Leave(CHARACTER.CAT);
        yield return new WaitForSeconds(10);
        Enter(CHARACTER.CAT);

        yield return new WaitForSeconds(3);
        Leave(CHARACTER.GIRL);
        yield return new WaitForSeconds(3);
        Enter(CHARACTER.GIRL);
    }
}
