using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(Movement))]
public class Character : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Movement _movement;

    public Rigidbody2D Rigidbody => _rigidbody;
    public Animator Animator => _animator;
    public Movement Movement => _movement;

    private void Start()
    {
        GetComponents();
    }

    protected virtual void GetComponents()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
    }
}
