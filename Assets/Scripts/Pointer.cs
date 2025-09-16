using System;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Clicker _clicker;
    [SerializeField] private float _rayDistance = 100f;

    public event Action<Cube> Pointed;

    private void OnEnable()
    {
        _clicker.Clicked += Point;
    }

    private void OnDisable()
    {
        _clicker.Clicked -= Point;
    }

    private void Point()
    {
        Cube cube = Raycast();

        if (cube != null)
            Pointed?.Invoke(cube);
    }

    private Cube Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance))
        {
            Collider collider = hit.collider;
            collider.TryGetComponent(out Cube cube);

            if (cube != null)
                Debug.LogWarning("Cube component не найден на объекте: " + hit.collider.name);
        }

        return null;
    }
}