
using UnityEngine;

public class Pastel : MonoBehaviour
{
    [SerializeField] private PastelTypeData pastelType;

    private bool collected;

    public void Initialize(PastelTypeData data)
    {
        pastelType = data;
        collected = false;

        Renderer visual = GetComponentInChildren<Renderer>();
        if (visual != null)
            visual.material.color = data.color;
    }

    private void Start()
    {
        if (pastelType != null)
            Initialize(pastelType);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collected || pastelType == null)
            return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            if (GameServices.Game != null)
                GameServices.Game.Collect(pastelType.points);

            Debug.Log(
                "Coletou " + pastelType.pastelName +
                ". Pontos: " + pastelType.points
            );

            Destroy(gameObject);
        }
    }
}
