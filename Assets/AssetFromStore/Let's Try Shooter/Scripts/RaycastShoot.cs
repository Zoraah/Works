using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    private int _gunDamage = 1;
    private float _fireRate = .25f;
    private float _weaponRange = 50f;
    private float _hitForce = 100f;
    [SerializeField]
    private Transform _gunEnd;
    private Camera _fpsCam;
    private WaitForSeconds _shotDuration = new WaitForSeconds(0.07f);
    private AudioSource _gunAudio;
    private LineRenderer _laserLine;
    private float _nextFire;

    private void Start()
    {
        _laserLine = GetComponent<LineRenderer>();
        _laserLine.startWidth = 0.05f;
        _laserLine.endWidth = 0.05f;
        _gunAudio = GetComponent<AudioSource>();
        _fpsCam = GetComponentInParent<Camera>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            StartCoroutine(ShootEffect());

            Vector3 _rayOrigin = _fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit _hit;
            _laserLine.SetPosition(0, _gunEnd.position);

            if (Physics.Raycast(_rayOrigin, _fpsCam.transform.forward, out _hit, _weaponRange))
            {
                _laserLine.SetPosition(1, _hit.point);
                ShootableBox _health = _hit.collider.GetComponent<ShootableBox>();
                if(_health!=null)
                {
                    _health.Damage(_gunDamage);
                }
                if(_hit.rigidbody!=null)
                {
                    _hit.rigidbody.AddForce(-_hit.normal * _hitForce);
                }
            }
            else
            {
                _laserLine.SetPosition(1, _rayOrigin + (_fpsCam.transform.forward * _weaponRange));
            }
        }
    }
    private IEnumerator ShootEffect()
    {
        _gunAudio.Play();
        _laserLine.enabled = true;
        yield return _shotDuration;
        _laserLine.enabled = false;
    }
}
