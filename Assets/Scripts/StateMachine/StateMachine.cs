using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;

    public State Current => _currentState;

    private void Reset()
    {
        Transit(_firstState);
    }

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNext();

        if (nextState != null)
            Transit(nextState);
    }


    private void Transit(State nextState)
    {
        _currentState?.Exit();
        _currentState = nextState;
        _currentState?.Enter();
    }
}
