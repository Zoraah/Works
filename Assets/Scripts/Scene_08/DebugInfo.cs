using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInfo : MonoBehaviour
{

    private void Start()
    {
        GetComponent<PlayerScript>().CastSecondDebugEvent += Debug.Log;
    }
}
