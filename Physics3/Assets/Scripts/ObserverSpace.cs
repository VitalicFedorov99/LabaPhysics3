using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverSpace : MonoBehaviour
{
    private static Attractors[] attractors;
    private static float _massSolnc;
    private static Vector3 _positionSolnc;
    // Start is called before the first frame update
    private void Start()
    {
        attractors = FindObjectsOfType<Attractors>();
        var solnc = GameObject.FindGameObjectWithTag("Solnc");
        _massSolnc = solnc.GetComponent<Rigidbody>().mass;
        _positionSolnc = solnc.GetComponent<Transform>().position;
    }

    public static Attractors[] GetAllAttractors()
    {
        return attractors;
    }

    public static float GetMassSolnc()
    {
        return _massSolnc;
    }

    public static Vector3 GetPositionSolnc()
    {
        return _positionSolnc;
    }
}
