using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCristal : MonoBehaviour
{
    [SerializeField] private Cristall _prefab;
    [SerializeField] private float _time;
    [SerializeField] private Transform _spaceShip;
    [SerializeField] private float _min;
    [SerializeField] private float _max;

    private void Start()
    {
        StartCoroutine(CoroutineCreateCrystal());
    }

    private void Create()
    {
        var randX = Random.Range(_min, _max);
        var randY = Random.Range(_min, _max);
        var randZ = Random.Range(_min, _max);
        Cristall crist = Instantiate(_prefab, new Vector3(_spaceShip.transform.position.x + randX, _spaceShip.transform.position.y + randY, _spaceShip.transform.position.z + randZ), Quaternion.identity);
        //crist.CountEnergy=
    }
    IEnumerator CoroutineCreateCrystal()
    {
        Create();
        yield return new WaitForSeconds(_time);
        StartCoroutine(CoroutineCreateCrystal());

    }
}
