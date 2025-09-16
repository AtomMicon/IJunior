using System;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public event Action Clicked;
    private const int LeftMouseButton = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            Clicked?.Invoke();
        }
    }
}
