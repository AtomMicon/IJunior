using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _clicker;
    [SerializeField] private float _rayDistance = 100f;

    public event Action<Cube> Pointed;

    private void OnEnable()
    {
        _clicker.Clicked += SelectCube;
    }

    private void OnDisable()
    {
        _clicker.Clicked -= SelectCube;
    }

    private void SelectCube()
    {
        Cube cube = Raycast();

        if (cube != null)
            Pointed?.Invoke(cube);
    }

    private Cube Raycast()
    {
        Ray ray = GetRay();

        if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance))
        {
            Collider collider = hit.collider;
            
            if (collider.TryGetComponent(out Cube cube))
                return cube;
            else
                Debug.LogWarning("Cube component не найден на объекте: " + hit.collider.name);

        }

        return null;
    }

    private Ray GetRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}