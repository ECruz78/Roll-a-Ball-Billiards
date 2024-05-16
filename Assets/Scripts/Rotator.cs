using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
		//Rotate the object on X, Y and z axes by specified amounts, adjusted for frame rate.
     transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);    
    }
}
