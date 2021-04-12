using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Enemy"))
        {
            var gameObjectProperties = collider.GetComponent<Character2DController>();
            gameObjectProperties.CambioDeVelocidad = 0.2f;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Enemy"))
        {
            var gameObjectProperties = collider.GetComponent<Character2DController>();
            gameObjectProperties.CambioDeVelocidad = 1;
        }
    }
}
