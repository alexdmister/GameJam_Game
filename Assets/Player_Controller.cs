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
        Walk();
        Jump();
        SlowWalk();
        InteractWithSmth();
    }

    public float speed = 5, Jump_Power = 500, slow_speed = 2;
    private bool onGround = true;



    public LayerMask layerOnGround;
    public LayerMask interactiveLayer;

    private float groundconnection = 0.8f;
    //private float interactSphere_radius = transform.localScale.x;
   // private float interactSphere_radius = 1.5f;
   // private GameObject 


    private void Walk() 
    {
        //     Player_Body.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, Player_Body.velocity.y, Player_Body.velocity.z);
        Player_Body.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, Player_Body.velocity.y, Input.GetAxis("Vertical") * speed);
    }

    private void SlowWalk()
    {
        if(Input.GetKey(KeyCode.LeftShift))
            Player_Body.velocity = new Vector3(Input.GetAxis("Horizontal") * slow_speed, Player_Body.velocity.y, Input.GetAxis("Vertical") * slow_speed);
    }

    private void Jump()
    {
        //  if (Physics.OverlapSphere(GroundCheckSphere.position, 0.5f)[0].na);
        onGround = Physics.Raycast(transform.position, Vector3.down, groundconnection, layerOnGround.value);
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
            Player_Body.AddForce(new Vector3(0,Jump_Power,0));
    }

    /*   private void interactSphere()
       {
          if (Physics.OverlapSphere(transform.position, interactSphere_radius, interactiveLayer) != null)
           Debug.Log(Physics.OverlapSphere(transform.position, interactSphere_radius, interactiveLayer)[0].name);

       }
    */

    private GameObject interactAim = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("interactive"))
        {
            interactAim = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == interactAim)
            interactAim = null;
    }

    private void InteractWithSmth() //Вставить в update
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactAim != null)
            {
                Debug.Log(interactAim.name);
            }
        }

    }
}
