using UnityEngine;

public class MetaController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Irse a la ultima escena una vez llegada a la meta
        }
    }
}
