using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerAnimatorController))]
public class PlayerController : MonoBehaviour
{
    private const string NextTarget = "NextTarget";
    private const string Death = "Death";

    [SerializeField] private Transform[] _points;

    private PlayerAnimatorController _animator;

    private NavMeshAgent _agent;

    private Transform _targetPoint;

    private int _currentPoint;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<PlayerAnimatorController>();
    }


    public void MoveNextTarget()
    {
        _targetPoint = _points[_currentPoint];

        float dist = Vector3.Distance(transform.position, _targetPoint.position);

        if (dist <= 0.5)
        {
            if (_currentPoint >= _points.Length)
            {
                _targetPoint = _points[_currentPoint];
            }
        }

        Debug.Log(_currentPoint);

        _currentPoint++;

        _agent.destination = _targetPoint.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Death))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(NextTarget))
        {
            _animator.StopAnimationWalk();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(NextTarget))
        {
            _animator.StartAnimationWalk();
        }
    }

}


