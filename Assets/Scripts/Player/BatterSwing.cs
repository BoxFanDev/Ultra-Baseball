using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterSwing : MonoBehaviour
{
    private float timeAttack;
    public float startTimeAttack;

    [SerializeField] private Transform attackPos;
    public float attackRangeX;
    public float attackRangeY;
    public LayerMask balls;

    public Animator anim;
    public bool swing;

    void Awake()
    {
        anim = GameObject.Find("AttackPos").GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (timeAttack <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Collider2D[] ballToHit = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), balls);
                for (int i = 0; i < ballToHit.Length; i++)
                {
                    ballToHit[i].GetComponent<Ball>().Fly();
                    anim.SetBool("swing", true);
                    Invoke("SetBoolBack", .1f);
                }

                timeAttack = startTimeAttack;
            }
            else
            {
                timeAttack -= Time.deltaTime;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.matrix = attackPos.transform.localToWorldMatrix;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector2(attackRangeX, attackRangeY));
    }

    void SetBoolBack()
    {
        anim.SetBool("swing", false);
    }
}
