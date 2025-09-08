using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int _fragmentationChanceDecrease = 2;
    [SerializeField] private InputRaycast _inputRaycast;

    public int FragmentIteration { private get; set; } = 1;
    private int _fragmentationMaxChance = 100;
    private float _fragmentIterationScale = 0.5f;
    private int _fragmentationCountMax = 6;
    private int _fragmentationCountMin = 2;

    private void OnEnable()
    {
        _inputRaycast.Click += OnClick;
    }

    private void OnDisable()
    {
        _inputRaycast.Click -= OnClick;
    }

    private void OnClick()
    {
        int fragmentationChance = _fragmentationMaxChance;

        for (int i = 0; i < FragmentIteration; i++)
        {
            fragmentationChance /= _fragmentationChanceDecrease;
        }

        Fragmentation(fragmentationChance);
    }

    public void Fragmentation(int fragmentationChance)
    {
        int fragmentationRoll = Random.Range(0, 100);
        int fragmentCount = Random.Range(_fragmentationCountMin, _fragmentationCountMax);

        Object.Destroy(gameObject);

        if (fragmentationRoll < fragmentationChance * _fragmentationChanceDecrease)
        {
            for (int i = 0; i < fragmentCount; i++)
            {
                ObjectCreate();
            }
        }
    }

    private void ObjectCreate()
    {
        GameObject fragment = Instantiate(gameObject, transform.position, Quaternion.identity);

        float newScale = transform.localScale.x * _fragmentIterationScale;
        fragment.transform.localScale = new Vector3(newScale, newScale, newScale);

        Explosion explosion = fragment.GetComponent<Explosion>();
        if (explosion != null)
        {
            explosion.FragmentIteration = this.FragmentIteration + 1;
        }
    }
}
