using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlaner : MonoBehaviour
{
    [SerializeField] private string _namePlanet;
    [SerializeField] private LineRenderObserver _lineObs;
    [SerializeField] private Transform _placeSitDown;
    private void OnMouseDown()
    {
        _lineObs.SetTransform(transform, _namePlanet, _placeSitDown);
    }
}
