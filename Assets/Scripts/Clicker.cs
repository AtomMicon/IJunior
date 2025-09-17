using System;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private const int _click = 0;

    public event Action Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_click))
        {
            Clicked?.Invoke();
        }
    }

    public Ray GetRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
