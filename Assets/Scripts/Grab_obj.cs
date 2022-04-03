using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_obj : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform theDest;
    
    void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;

        Debug.Log("Grabbed!");
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}

