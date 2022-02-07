using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioClip[] homeruns;

    public float moveSpeed = 10f;

    Rigidbody2D rb;

    Batter target;
    Vector2 moveDir;
    //Collider coll;

    public GameObject breakPrefab;

    float force = 1000;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Batter>();
        moveDir = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Batter"))
        {
            
            Debug.Log("STRIKE!");
            Destroy(gameObject);
            target.GetComponent<HealthSystem>().TakeDamage(1);
        }

        if (col.gameObject.name.Equals("Square"))
        {
            Debug.Log("Ball!");
            Destroy(gameObject);
        }
    }

    //public void OnTriggerEnter(Collider coll)
    //{
    //    var collisionPoint = coll.ClosestPoint(transform.position);
    //    var collisionNormal = transform.position - collisionPoint;
    //}

    public void Fly()
    {
        //var collisionPoint = coll.ClosestPoint(transform.position);
        //var collisionNormal = transform.position - collisionPoint;
        moveDir = -moveDir;
        rb.AddForce(moveDir * force);
        FindObjectOfType<HitStop>().Stop(0.03f);
        AudioManager.instance.RandomSFX(homeruns);
    }
}
