using UnityEngine;

public static class AnimatorData
{
    public static class Params
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
        public static readonly int IsLanding = Animator.StringToHash(nameof(IsLanding));
        public static readonly int IsJump = Animator.StringToHash(nameof(IsJump));
        public static readonly int IsFallDown = Animator.StringToHash(nameof(IsFallDown));
    }
}
