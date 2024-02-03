using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform FirePosition; 

    
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(BulletPrefab , FirePosition.position ,Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) 
        {
            Destroy(gameObject); 
        }
    }

}
