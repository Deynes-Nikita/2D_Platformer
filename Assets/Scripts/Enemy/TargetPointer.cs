using System.Collections.Generic;
using UnityEngine;

public class TargetPointer : MonoBehaviour
{
    [SerializeField] private Transform _patrolPoints;

    private List<Vector2> _targetPoints = null;
    private int _currentTargetPointsNumber = 0;


    private void Start()
    {
        if (_patrolPoints != null)
        {
            _targetPoints = new List<Vector2>();

            for (int i = 0; i < _patrolPoints.childCount; i++)
            {
                Vector2 targetPoint = _patrolPoints.GetChild(i).position;              
                _targetPoints.Add(targetPoint);
            }
        }
    }

    public bool TryDefineTarget(out Vector2 currentTargetPosition)
    {
        if (_targetPoints == null)
        {
            currentTargetPosition = Vector2.zero;
            return false;
        }
        
        currentTargetPosition = _targetPoints[_currentTargetPointsNumber];

        bool isTargetPosition = Mathf.Ceil(transform.position.x) == Mathf.Ceil(currentTargetPosition.x);

        if (isTargetPosition)
        {
            _currentTargetPointsNumber = ++_currentTargetPointsNumber % _targetPoints.Count;
            currentTargetPosition = _targetPoints[_currentTargetPointsNumber];
        }

        return true;
    }
}
