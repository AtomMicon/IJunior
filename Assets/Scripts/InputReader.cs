using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int Click = 0;

    public event Action Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(Click))
        {
            Clicked?.Invoke();
        }
    }
}
