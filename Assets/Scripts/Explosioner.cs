using UnityEngine;

public class Explosioner : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
