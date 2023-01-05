
using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    float velocity = 10;

    [SerializeField]
  public  int damage = 20;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 6, true);
        Physics2D.IgnoreLayerCollision(7, 7, true);
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocity* Time.deltaTime);
    }

    public IEnumerator Activeshoot()
    {

         yield return new WaitForSeconds(2.1f);
        this.gameObject.SetActive(false);
    }

    public void Active()
    {
        this.gameObject.SetActive(true);
    }


    void OnCollisionEnter2D(Collision2D collPlay)
    {

        this.gameObject.SetActive(false);
      //  rigidbody2D.isKinematic = true;
        

        if (collPlay.gameObject.tag != "Enemy")
        {
           
        }

    }
}
