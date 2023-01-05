using UnityEngine;
using UnityEngine.Events;

public class MachineCollider : MonoBehaviour
{
    [SerializeField]
    int Damage;

    [SerializeField]
    UnityEvent onTouchenemy;

    [SerializeField]
    bool isActiveEvent;

    void OnTriggerEnter2D(Collider2D col)
    {
        ///verificar
        if (col.gameObject.CompareTag("Enemy"))
        {
          StartCoroutine(col.gameObject.GetComponent<EnemyCollider>().Damage(Damage));
            if (isActiveEvent)
               onTouchenemy.Invoke();
        }

    }
}
