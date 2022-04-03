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
        GrabObj();
        DragObj();
        DropObj();
    }

    public float speed = 5, Jump_Power = 500, slow_speed = 2;
    private bool onGround = true;



    public LayerMask layerOnGround;
    public LayerMask interactiveLayer;

    private float groundconnection = 0.8f;



    private void Walk()
    {
        Player_Body.transform.localScale = new Vector3(Player_Body.transform.localScale.x * 1, Player_Body.transform.localScale.y*1, Player_Body.transform.localScale.z*1);
        Player_Body.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, Player_Body.velocity.y, Input.GetAxis("Vertical") * speed);
    }

    private void SlowWalk()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            Player_Body.velocity = new Vector3(Input.GetAxis("Horizontal") * slow_speed, Player_Body.velocity.y, Input.GetAxis("Vertical") * slow_speed);
    }

    private void Jump()
    {
        onGround = Physics.Raycast(transform.position, Vector3.down, groundconnection, layerOnGround.value);
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
            Player_Body.AddForce(new Vector3(0, Jump_Power, 0));
    }

    private GameObject interactAim = null;
    private GameObject gateAim = null;

    private bool grabbed = false;

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
    private void GrabObj()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactAim != null && grabbed == false)
        {
            interactAim.GetComponent<Rigidbody>().useGravity = false;
            interactAim.transform.position = GameObject.Find("Grabb_zone").transform.position;
            GetComponentInChildren<SphereCollider>().enabled = false;
            grabbed = !grabbed;
            Debug.Log("Grabbed!");
        }
    }
    private void DragObj()
    {
      if (grabbed && interactAim != null)
            interactAim.transform.position = GameObject.Find("Grabb_zone").transform.position;
    }

    private void DropObj()
    {
        if (Input.GetKeyDown(KeyCode.F) && grabbed == true)
        {
            interactAim.GetComponent<Rigidbody>().useGravity = true;
            interactAim.transform.position = GameObject.Find("Grabb_zone").transform.position;
            GetComponentInChildren<SphereCollider>().enabled = true;
            grabbed = !grabbed;
            Debug.Log("Dropped!");
        }
    }
}
    


