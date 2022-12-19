using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField] private Transform _objectFollow;
    [SerializeField] private Vector3 _deltaPos;
    [SerializeField] private Camera _camera;
    void Start()
    {
        _deltaPos = transform.position - _objectFollow.position;
       // transform.LookAt(_camera.ScreenPointToRay(Input.mousePosition).GetPoint(0));
    }

    public void UpdateLookAt()
    {
        transform.LookAt(_objectFollow);
    }
    void Update()
    {
        transform.position = _objectFollow.position + _deltaPos;
    }
}
