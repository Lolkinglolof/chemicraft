using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    public bool hang;
    public bool grabbed;
    public bool passive;
    private string previous;
    GameObject scroll = null;
    public GameObject passivescroll;
    public GameObject hangingscroll;
    public GameObject grabbedscroll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scroll != null)
            Instantiate(passivescroll);
        if (hang == true && previous != "hang")
        {
            Destroy(scroll);
            scroll = Instantiate(hangingscroll, transform);
            previous = "hang";
        }
        if (grabbed == true && previous != "grabbed")
        {
            Destroy(scroll);
            scroll = Instantiate(grabbedscroll, transform);
            previous = "grabbed";
        }
        if (passive == true && previous != "passive")
        {
            Destroy(scroll);
            scroll = Instantiate(passivescroll, transform);
            previous = "passive";
        }

    }
}
