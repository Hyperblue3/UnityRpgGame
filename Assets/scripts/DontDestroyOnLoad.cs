using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public Canvas mycanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        //mycanvas.GetComponent<canvas>();
        Canvas.DontDestroyOnLoad(mycanvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
