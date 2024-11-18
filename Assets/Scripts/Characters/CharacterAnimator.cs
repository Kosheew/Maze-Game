using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator 
{
    private Animator _animator;
    private int _attackHash;
    private int _runHash;
    
    public CharacterAnimator(Animator animator)
    {
        _animator = animator;
    }

    public void Attacking()
    {
        _animator.SetTrigger(_runHash);   
    }

    public void Running(float velocity)
    {
        _animator.SetFloat(_runHash, velocity);
    }
}
