using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameObject[] strikes;
    public int life;
    public bool dead;


    void Start()
    {
        life = strikes.Length;
    }


    void Update()
    {
        if (dead == true)
        {
            GameController.instance.EndGame();
            Debug.Log("URRRR OUT!!!!");
        }
    }

    public void TakeDamage(int d)
    {
        life -= d;
        Destroy(strikes[life].gameObject);
        if (life < 1)
        {
            dead = true;
        }
    }
}
