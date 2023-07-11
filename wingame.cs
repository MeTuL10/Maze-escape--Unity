using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wingame : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Player"))
            Destroy(other.gameObject);
        //gos = GameObject.FindGameObjectsWithTag("enemy");
        //if (other.gameObject.CompareTag("Player"))
        //    for (int i=0;i<5;i++)
                
    }
}
