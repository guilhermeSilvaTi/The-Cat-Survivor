using System.Collections;
using TMPro;
using UnityEngine;


public class HitText : MonoBehaviour
{
   
    float velocity = 2;

    [SerializeField]
    TextMeshProUGUI textValue;
    void Update()
    {
        transform.Translate(Vector2.up * velocity * Time.deltaTime);
    }

    public IEnumerator DelayDisable()
    {
        yield return new WaitForSeconds(0.4f);
         this.gameObject.SetActive(false);
    }
    public void EnabledHit(int value)
    {
        textValue.text = "" + value;
        this.gameObject.SetActive(true);
    }

}
