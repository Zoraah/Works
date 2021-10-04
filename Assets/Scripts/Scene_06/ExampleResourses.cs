using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleResourses : MonoBehaviour
{
    private void Start()
    {
        AsphaltGenertor();
        CarGenerator();
    }
    private void AsphaltGenertor()
    {
        GameObject _asphalt = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Renderer _rend = _asphalt.GetComponent<Renderer>();
        _rend.material = Resources.Load("Materials/M_Asphalt_Way") as Material;
    }
    private void CarGenerator()
    {
        GameObject _car = Resources.Load("Cars/Car_01") as GameObject;
        _car.transform.position = new Vector3(0f, 1f, 0f);
        _car.name = "Car";
        Instantiate(_car);
    }
}
