using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _offset;
    [SerializeField] private float _speedRotate = 10;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    private float InputX;
    private float InputY;

    [SerializeField] private float smoothTime = 1f;

    private Vector3 currentRotation;
    private Vector3 currentVelocity;


    void Start()
    {
        _offset = transform.position - _player.position;
        transform.LookAt(_player);
    }

    private void LateUpdate()
    {
   //     InputX += Input.GetAxis("Mouse X") * _speedRotate;
     //   InputY += Input.GetAxis("Mouse Y") * _speedRotate;

       // InputY = Mathf.Clamp(InputY, _minY, _maxY);
       // InputX = Mathf.Clamp(InputX, _minX, _maxX);

       // currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(InputY, InputX), ref currentVelocity, smoothTime);
       // transform.eulerAngles = currentRotation;

        transform.position = _player.position + _offset;
    }
    



}

/*
    [SerializeField] private Transform _objectFollow;
    [SerializeField] private Vector3 _deltaPos;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;
    void Start()
    {
        _deltaPos = transform.position - _objectFollow.position;
        UpdateLookAt();
       // transform.LookAt(_camera.ScreenPointToRay(Input.mousePosition).GetPoint(0));
    }

    public void UpdateLookAt()
    {
        transform.LookAt(_objectFollow);
    }
    /*  void Update()
      {
          //transform.position = _objectFollow.position + _deltaPos;
          //transform.LookAt(_objectFollow);
          transform.position = _objectFollow.position + _deltaPos;
          if (Input.GetKey(KeyCode.Z))
          {
              transform.Rotate(Vector3.up);
          }
          if (Input.GetKey(KeyCode.C))
          {
              transform.Rotate(Vector3.down);
          }
      }*/

//  private void FixedUpdate()
//{
//  transform.position = _objectFollow.position + _deltaPos;
/*if (Input.GetKey(KeyCode.W))
{
    transform.Rotate(Vector3.forward * _speed * Time.fixedDeltaTime);

}

if (Input.GetKey(KeyCode.S))
{
    transform.Rotate(Vector3.back * _speed * Time.fixedDeltaTime);

}
if (Input.GetKey(KeyCode.A))
{
    transform.Rotate(Vector3.down * _speed * Time.fixedDeltaTime);

}
if (Input.GetKey(KeyCode.D))
{
    transform.Rotate(Vector3.up * _speed * Time.fixedDeltaTime);

}*/
// }


