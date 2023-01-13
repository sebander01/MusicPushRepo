using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ThrustObject : MonoBehaviour
{
    public GameObject pushItem;
    public GameObject pointFront;
    public GameObject pointRear;
    public float pushSpeed;
    public int delayS;
    public Rigidbody rb;
    public float timer;
    public Vector3 position;
    public bool switchl;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        Thrust();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void Thrust()
    {
        if(!switchl)
        {
            position = pointRear.transform.position;
        }
        else if(switchl)
        {
            position = pointFront.transform.position;
        }

        if (timer >= delayS)
        {
            switchl = !switchl;
            timer = 0;
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, position, pushSpeed * Time.deltaTime);
        }


    }
}
