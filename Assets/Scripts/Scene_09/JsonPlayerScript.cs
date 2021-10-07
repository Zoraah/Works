using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class JsonPlayerScript : MonoBehaviour
{
    private float _turnSpeed = 90f;
    private float _moveSpeed = 2f;
    public PlayerStats Player;
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        LoadData();
    }

    private void Update()
    {
        Move();
        LvlControl();
        DataControl();
    }
    private void SaveData()
    {
        string _data = JsonUtility.ToJson(Player);
        File.WriteAllText(Application.streamingAssetsPath + "/Data.json", _data);
    }
    private void LoadData()
    {
        if (File.Exists(Application.streamingAssetsPath + "/Data.json"))
        {
            string _data = File.ReadAllText(Application.streamingAssetsPath + "/Data.json");
            Debug.Log(_data);
            Player = JsonUtility.FromJson<PlayerStats>(_data);
        }
        else
        {
            Player.StartStats();
        }
    }
    private void DataControl()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadData();
        }
    }
    private void LvlControl()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Player.LvlUp();
        }
    }
    private void Move()
    {
        float _hMove = Input.GetAxis("Horizontal");
        float _vMove = Input.GetAxis("Vertical");
        _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(new Vector3(0f, _turnSpeed, 0f) * _hMove * Time.deltaTime));
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * _moveSpeed * _vMove * Time.deltaTime);
    }

    [Serializable]
    public struct PlayerStats
    {
        public int _lvl;
        public int _lvlPoints;
        public void StartStats()
        {
            _lvl = 1;
            _lvlPoints = 0;
        }
        public void LvlUp()
        {
            _lvl++;
            _lvlPoints += 2;
        }
    }
}
