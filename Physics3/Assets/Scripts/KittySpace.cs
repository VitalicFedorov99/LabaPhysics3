using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittySpace : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _spaceShip;

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(_spaceShip);
        //�������� ������� ������� �� �������. ������ ���  ������������ ������� �� X, ��� ������ �� �����.
    }
}
