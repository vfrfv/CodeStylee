using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _points;

    private int _currentIndexPlace;

    private Transform[] _places;

    private void Start()
    {
        _currentIndexPlace = 0;

        _places = new Transform[_points.childCount];

        for (int i = 0; i < _points.childCount; i++)
        {
            _places[i] = _points.GetChild(i);
        }
    }

    private void Update()
    {
        Transform place = _places[_currentIndexPlace];

        transform.position = Vector3.MoveTowards(transform.position, place.position, _speed * Time.deltaTime);

        if (transform.position == place.position)
        {
            SetNextPlace();
        }
    }

    private void SetNextPlace()
    {
        _currentIndexPlace++;

        if (_currentIndexPlace >= _places.Length)
        {
            _currentIndexPlace = 0;
        }

        Vector3 pointVector = _places[_currentIndexPlace].transform.position;
        transform.forward = pointVector - transform.position;
    }
}
