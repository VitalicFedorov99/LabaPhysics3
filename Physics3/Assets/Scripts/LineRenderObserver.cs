using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderObserver : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private SpaceShip _ship;
    private string _namePlanet;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 0;
        _lineRenderer.positionCount = _lineRenderer.positionCount + 2;
    }


    public void SetTransform(Transform point,string name, Transform placeSitDown)
    {
        _namePlanet = name;
        _point1 = point;
        
    }
    private void FixedUpdate()
    {
        UpdateLine();
    }
    public void UpdateLine()
    {
        _lineRenderer.SetPosition(0, _point1.position);
        _lineRenderer.SetPosition(1, new Vector3 (_point2.position.x+10,_point2.position.y,_point2.position.z));

    }
    
}
