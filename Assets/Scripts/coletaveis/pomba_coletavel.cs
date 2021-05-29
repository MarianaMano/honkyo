using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pomba_coletavel : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(new Vector3(45, 0, 0) * Time.deltaTime);
    }
}
