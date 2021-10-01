using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour
{
    private float _weaponRange = 50f;
    private Camera _fpsCam;
    private void Start()
    {
        _fpsCam = GetComponentInParent<Camera>();

    }

    private void Update()
    {
        Vector3 _lineOrigin = _fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        Debug.DrawLine(_lineOrigin, _fpsCam.transform.forward * _weaponRange, Color.green);
    }
}
