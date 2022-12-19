using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractors : MonoBehaviour
{
    private const float G = 6.674f; 
    [SerializeField] private Rigidbody _rb;
    private bool firstAngularForce = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        foreach (var attractor in ObserverSpace.GetAllAttractors())
        {
            if (attractor != this)
                Attract(attractor);
        }
        _rb.angularVelocity = new Vector3(0, 0.06f, 0);
    }

    private void Attract(Attractors objToAttract)
    {
        Rigidbody rbToAttract = objToAttract._rb;

        Vector3 direction = _rb.position - rbToAttract.position;
        float distance = direction.magnitude / 2;

        float forceMagnitude = (G * (_rb.mass * rbToAttract.mass)) / (distance * distance);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);

        if (tag == "Solnc")
            return;

        if (!firstAngularForce)
            return;

        float angularForce = (G * ObserverSpace.GetMassSolnc()) / (Vector3.Distance(transform.position, ObserverSpace.GetPositionSolnc() * 25));
        Vector3 orbit = (new Vector3(angularForce, 0, 0) * Time.deltaTime);
        _rb.velocity += (orbit);
        firstAngularForce = false;
    }

    public static float GetGravityConst()
    {
        return G;
    }
}
