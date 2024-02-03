using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public AudioClip coinSound;


    public Item(string name, string description)
    {
        itemName = name;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Destroy(other.gameObject);

            AudioSource.PlayClipAtPoint(coinSound, transform.position);



        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
