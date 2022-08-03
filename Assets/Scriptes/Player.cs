using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float _speed;

    private MoveSequence _sequence;

    private void Awake()
    {
        _sequence = new MoveSequence(_speed, this);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            touchPosition.z = 0;

            _sequence.Add(touchPosition);
        }
    }
}

public class MoveSequence
{
    private Queue<Vector3> _positions = new Queue<Vector3>();

    private float _speed;
    private MonoBehaviour _target;
    private bool _isMoving;

    public MoveSequence(float speed, MonoBehaviour target)
    {
        _speed = speed;
        _target = target;
    }

    public void Add(Vector3 position)
    {
        _positions.Enqueue(position);

        if (_isMoving == false)
        {
            StartMoving();
        }
    }

    private void StartMoving()
    {
        _isMoving = true;

        _target.StartCoroutine(GetMoving());
    }

    private IEnumerator GetMoving()
    {
        while (_positions.Count > 0)
        {
            var targetPosition = _positions.Dequeue();
            var transform = _target.transform;

            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetPosition,
                    Time.deltaTime * _speed);

                yield return null;
            }

            transform.position = targetPosition;
        }

        _isMoving = false;
    }
}
