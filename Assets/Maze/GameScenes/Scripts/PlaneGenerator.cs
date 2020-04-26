using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGenerator : MonoBehaviour
{

    public GameObject Plane;
    int x, z;

    // Start is called before the first frame update
    void Start()
    {
        for (x = 0; x <= HomeDirector.width; x++)
        {
            for (z = 0; z <= HomeDirector.height; z++)
            {
                GameObject PlaneGen = Instantiate(Plane) as GameObject;
                PlaneGen.transform.position = new Vector3(x, 0, z);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
