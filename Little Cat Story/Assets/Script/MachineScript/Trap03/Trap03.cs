using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap03 : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D boxCollider2D;

    [SerializeField]
    Animator animator;

   public void DestroyTrap()
    {
        boxCollider2D.enabled = false;
        animator.SetInteger("Trap", 1);
        StartCoroutine(DesactiveThis());
    }

    public IEnumerator DesactiveThis()
    {
        yield return new WaitForSeconds(0.7f);
        this.gameObject.SetActive(false);
    }
}
