using System.Collections.Generic;
using Mechanics;
using UnityEngine;

public class CristalManager : MonoBehaviour
{
    [SerializeField] private List<PlanetOrbit> _planets = new List<PlanetOrbit>();
    [SerializeField] private CristalView _cristal;

    private void Start()
    {
        foreach (var planet in _planets)
        {
            for (int i = 0; i < 12; i++)
            {
                var cristal = Instantiate(_cristal, planet.transform);
                cristal.TransformCristal.localPosition = Vector3.right;
                cristal.TransformCristal.localScale *= 0.1f;
                cristal.transform.rotation = Quaternion.Euler(Vector3.up * 30f * i);
            }
        }
    }
}
