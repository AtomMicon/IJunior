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
                Explosioner explosion = hit.collider.GetComponent<Explosioner>();
                Spawner spawner = hit.collider.GetComponent<Spawner>();

                if (explosion != null)
                {
                    explosion.Explosion();
                    spawner.Spawn();
                }
            }
        }
    }
}
