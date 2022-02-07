using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitcher : MonoBehaviour
{
    [SerializeField]
    GameObject ball;

    float fireRate;
    float nextFire;


    // Start is called before the first frame update
    void Start()
    {
            fireRate = 1f;
            nextFire = Time.time;        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.gamePlaying)
        {
            CheckIfTimeToFire();
        }
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(ball, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
