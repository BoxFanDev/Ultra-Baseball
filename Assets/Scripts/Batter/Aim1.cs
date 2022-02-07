using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim1 : MonoBehaviour
{
    private Vector2 rightStickInput;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        if (rightStickInput.magnitude > 0f)
        {
            Vector3 curRotation = Vector3.left * rightStickInput.x + Vector3.up * rightStickInput.y;
            Quaternion playerRotation = Quaternion.LookRotation(curRotation, Vector3.forward);

            rb.SetRotation(playerRotation);
        }
    }

    private void GetPlayerInput()
    {
        rightStickInput = new Vector2(Input.GetAxis("R_Horizontal"), (Input.GetAxis("R_Vertical")));
    }
}
