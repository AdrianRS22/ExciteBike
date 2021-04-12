using UnityEngine;
using UnityEngine.Events;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    public UnityEvent enfriarTemporizador;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            enfriarTemporizador?.Invoke();
        }
    }
}
