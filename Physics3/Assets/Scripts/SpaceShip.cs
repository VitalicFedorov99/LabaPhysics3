using UnityEngine;
using System.Collections;
public class SpaceShip : MonoBehaviour
{
    [SerializeField] private float _fuel = 150f;
    [SerializeField] private float _speed;
    [SerializeField] private MoveCamera _camera;
    private Rigidbody _rb;
    private const float _thrust = 0.13f;
    private const float _fuelPerSecond = 0.3f;
    private Transform _planet;
    private Transform _placeSitDown;
    private bool _flyFlag = false;
    private bool _sitDownFlag = false;
    private bool _sitDown = false;

    public void SetTransform(Transform planet,Transform placeSitDown)
    {
        _planet = planet;
        _placeSitDown = placeSitDown;
        _flyFlag = true;
       // transform.LookAt(_planet);
    }

    public void TakeOff()
    {
        transform.parent = null;
        _rb.isKinematic = false;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 20);
            _camera.UpdateLookAt();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -20);
            _camera.UpdateLookAt();
        }
    }
    private void FixedUpdate()
    {
       // transform.LookAt(_camera.ScreenPointToRay(Input.mousePosition).GetPoint(0));
        MoveShip();
    }

    private void MoveShip()
    {
        foreach (var attractor in ObserverSpace.GetAllAttractors())
        {
            if (Vector3.Distance(transform.position, attractor.transform.position) < 1.5f)
            {
                var massPlanet = attractor.GetComponent<Rigidbody>().mass;
                Vector3 direction = _rb.position - attractor.transform.position;
                float distance = direction.magnitude / 2;

                float forceMagnitude = (Attractors.GetGravityConst() * (_rb.mass * massPlanet)) / (distance * distance);
                Vector3 force = direction.normalized * forceMagnitude;

                _rb.AddForce(force);
            }
        }
        if (_planet != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _planet.transform.position, _speed * Time.fixedDeltaTime);
            if (Vector3.Distance(_planet.position, transform.position) < 20)
            {
                _rb.isKinematic = true;
                transform.position = _placeSitDown.position;
                Debug.Log("Притягиваюсь");
                transform.SetParent(_placeSitDown);
                _planet = null;
            }
        }
    }


    
    


        /*  if (Input.GetKey(KeyCode.Space) && _fuel > 0)
          {
              _rb.AddForce(Vector3.up * 100 * (_thrust / _fuelPerSecond) * (_rb.mass / (_rb.mass + _fuel / 10)));
              _fuel -= _fuelPerSecond;
          }

          if (Input.GetKey(KeyCode.W) && _fuel > 0)
          {
              _rb.AddTorque(Vector3.right * 0.01f * Time.fixedDeltaTime);
              _fuel -= _fuelPerSecond;
          }
          if (Input.GetKey(KeyCode.S) && _fuel > 0)
          {
              _rb.AddTorque(Vector3.left * 0.01f * Time.fixedDeltaTime);
              _fuel -= _fuelPerSecond;
          }
          if (Input.GetKey(KeyCode.A) && _fuel > 0)
          {
              _rb.AddTorque(Vector3.down * 0.01f * Time.fixedDeltaTime);
              _fuel -= _fuelPerSecond;
          }
          if (Input.GetKey(KeyCode.D) && _fuel > 0)
          {
              _rb.AddTorque(Vector3.up * 0.01f * Time.fixedDeltaTime);
              _fuel -= _fuelPerSecond;
          }

          if (Input.GetKey(KeyCode.Return) && _fuel > 0)
          {
              _rb.AddForce(transform.TransformDirection(Vector3.left * Time.fixedDeltaTime * 3));
              _fuel -= _fuelPerSecond;
          }*/
  /*  IEnumerator CoroutineSitOnPlanet()
    {
       
        yield return new WaitForSeconds(10);
        Debug.Log("Приземляюсь");
        transform.position = _placeSitDown.position;
        transform.SetParent(_placeSitDown);
        _sitDown = true;
    }*/


    

}
