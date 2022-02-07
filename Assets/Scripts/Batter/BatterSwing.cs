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
    public bool swinging;

    public AudioClip[] swingSounds;

    void Awake()
    {
        anim = GameObject.Find("AttackPos").GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.gamePlaying)
        {
            if (Input.GetButtonDown("Fire1") && timeAttack <= 0)
            {
                Swing();

                AudioManager.instance.RandomSFX(swingSounds);

                timeAttack = startTimeAttack;
                anim.SetBool("swinging", true);
                Invoke("SetBoolBack", .1f);
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

    void Swing()
    {

        Collider2D[] ballToHit = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), balls);
        for (int i = 0; i < ballToHit.Length; i++)
        {
            ballToHit[i].GetComponent<Ball>().Fly();
            
        }

    }

    void SetBoolBack()
    {
        anim.SetBool("swinging", false);
    }

}
