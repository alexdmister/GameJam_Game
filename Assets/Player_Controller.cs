using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody Player_Body;

    // Start is called before the first frame update
    void Start()
    {
        Player_Body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        walk();
        jump();
    }

    public float speed = 5, Jump_Power = 500;
    private bool onGround = true;

    public LayerMask layerOnGround;

    private float GroundConnection = 0.8f;

    private void walk() 
    {
        Player_Body.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, Player_Body.velocity.y, Player_Body.velocity.z);
    }

  

    private void jump()
    {
        //  if (Physics.OverlapSphere(GroundCheckSphere.position, 0.5f)[0].na);
        onGround = Physics.Raycast(transform.position, Vector3.down, GroundConnection, layerOnGround.value);
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
            Player_Body.AddForce(new Vector3(0,Jump_Power,0));
    }

}
