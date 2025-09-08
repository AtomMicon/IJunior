using System;
using UnityEngine;

public class InputRaycast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private float _rayDistance = 100f;

    public event Action Click;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(_ray.origin, _ray.direction * _rayDistance, Color.red);

        CheckClick();
    }

    public void CheckClick()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(_ray, out hit, _rayDistance) == true)
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                Click?.Invoke();
            }
        }
    }
}
