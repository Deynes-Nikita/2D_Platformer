using UnityEngine;

public class MovementToTargetState : State
{
    [SerializeField] private float _speed = 1f;

    private Vector2 _currentPosition;
    private TargetPointer _targetPointer;

    private void FixedUpdate()
    {
        _targetPointer.TryDefineTarget(out Vector2 currentTargetPosition);

        float direction = currentTargetPosition.x - _currentPosition.x;

        Character.Movement.Move(Mathf.Sign(direction), _speed);

        float speed = Mathf.Abs(Character.Rigidbody.velocity.x);
        Character.Animator.SetFloat(AnimatorData.Params.Speed, speed);
    }

    protected override void GetComponents()
    {
        base.GetComponents();

        _targetPointer = GetComponentInParent<TargetPointer>();
        _currentPosition = transform.parent.position;
    }
}
