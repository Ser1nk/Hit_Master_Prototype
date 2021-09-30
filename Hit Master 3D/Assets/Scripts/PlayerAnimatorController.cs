using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
    private static readonly int isWalk = Animator.StringToHash("IsWalk");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartAnimationWalk()
    {
        _animator.SetBool(isWalk, true);
    }    

    public void StopAnimationWalk()
    {
        _animator.SetBool(isWalk, false);
    }


}
