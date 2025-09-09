using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private float rayDistance = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
            {
                Cube cube = hit.collider.GetComponent<Cube>();

                if (cube != null)
                {
                    cube.Explode();
                }
                else
                {
                    Debug.LogWarning("Cube component не найден на объекте: " + hit.collider.name);
                }
            }
        }
    }
}
