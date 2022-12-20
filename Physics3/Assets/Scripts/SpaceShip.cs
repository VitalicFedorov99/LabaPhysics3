using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class SpaceShip : MonoBehaviour
{
    [SerializeField] private float _fuel;
    [SerializeField] private float _maxFuel;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotate;
    [SerializeField] private Image _imageEnergy;
    [SerializeField] private Image _imageFly;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private TMP_Text _textScore;
    private int score = 0;

    private Vector3 _moveDirection;
    private Rigidbody _rb;
    // private const float _thrust = 0.13f;
    private const float _fuelPerSecond = 0.3f;
    [SerializeField] private bool _flyFlag = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _fuel = _maxFuel;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _flyFlag = !_flyFlag;
            _imageFly.gameObject.SetActive(_flyFlag);
            if (_flyFlag)
            {
                _particle.gameObject.SetActive(true);
                _particle.Play();
            }
            else
            {
                _particle.gameObject.SetActive(false);
            }
        }
        if (Input.GetKey(KeyCode.S) && _fuel > 0)
        {
            transform.Rotate(Vector3.forward * _speedRotate * Time.fixedDeltaTime);

        }

        if (Input.GetKey(KeyCode.W) && _fuel > 0)
        {
            transform.Rotate(Vector3.back * _speedRotate * Time.fixedDeltaTime);

        }
        if (Input.GetKey(KeyCode.A) && _fuel > 0)
        {
            transform.Rotate(Vector3.down * _speedRotate * Time.fixedDeltaTime);

        }
        if (Input.GetKey(KeyCode.D) && _fuel > 0)
        {
            transform.Rotate(Vector3.up * _speedRotate * Time.fixedDeltaTime);

        }
        UpdateUI();
    }


    private void FixedUpdate()
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
        if (_flyFlag)
        {
            MoveShip();
        }
    }


    private void UpdateUI()
    {
        if (_fuel > _maxFuel)
        {
            _fuel = _maxFuel;
        }
        _imageEnergy.fillAmount = _fuel / _maxFuel;
    }


    private void MoveShip()
    {

        if (_fuel > 0)
        {
            transform.Translate(-Vector3.right * _speed * Time.fixedDeltaTime);
            _fuel -= _fuelPerSecond;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Cristall cristall))
        {

            _fuel += cristall.CountEnergy;
            UpdateUI();
            score++;
            _textScore.text = score.ToString();
            Destroy(cristall.gameObject);
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
