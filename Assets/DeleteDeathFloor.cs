using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDeathFloor : MonoBehaviour
{
    public GameObject DeathFloor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Destroy(DeathFloor);
        }
    }
}
