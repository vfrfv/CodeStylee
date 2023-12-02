using UnityEngine;

public class PatrolMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform  _path;

    private int _currentIndexPlace;

    private Transform[] _places;

    private void Start()
    {
        _currentIndexPlace = 0;

        _places = new Transform[ _path.childCount];

        for (int i = 0; i <  _path.childCount; i++)
        {
            _places[i] =  _path.GetChild(i);
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

        Vector3 pointVector = _places[_currentIndexPlace].position;
        transform.forward = _places[_currentIndexPlace].position - transform.position;
    }
}
