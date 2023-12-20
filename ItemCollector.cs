using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public  Text carrotText;
    public AudioSource collect;
    private int carrot = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Carrot"))
        {
            collect.Play();
            Destroy(collision.gameObject);
            carrot++;
            Debug.Log("Carrot: " + carrot);
            carrotText.text = " Carrot :" + carrot;
        }
    }
    
}
