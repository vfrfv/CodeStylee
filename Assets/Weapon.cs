using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Weapon : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _number;
    [SerializeField] private float _timeWaitShooting;

    private Transform _pointShot;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = true;

        while (isWork)
        {
            Vector3 direction = (_pointShot.position - transform.position).normalized;
            Rigidbody rigidbodyBulle = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            _bulletPrefab.transform.up = direction;
            _bulletPrefab.velocity = direction * _number;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}
