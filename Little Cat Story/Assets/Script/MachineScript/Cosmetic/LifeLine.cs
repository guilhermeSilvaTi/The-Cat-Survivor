
using UnityEngine;

public class LifeLine : MonoBehaviour
{
    [SerializeField]
    int healing = 5;

    private void OnTriggerStay2D(Collider2D collision)
    {
        ///verificar
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Healing(healing);
        }
    }
   
}
