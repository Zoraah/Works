using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaverScript : MonoBehaviour
{
    [SerializeField]
    private int Count;
    private void SavePrefs()
    {
        PlayerPrefs.SetInt("Count", Count);
        PlayerPrefs.Save();
        Debug.Log("Prefs was saved");
    }
    private void LoadPrefs()
    {
        if (PlayerPrefs.HasKey("Count"))
        {
            Count = PlayerPrefs.GetInt("Count");
            Debug.Log("Prefs was loaded");
        }
        else
        {
            Debug.Log("Prefs not exist");
        }
    }
    private void DeletePrefs()
    {
        if (PlayerPrefs.HasKey("Count"))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Prefs was deleted");
        }
        else
        {
            Debug.Log("Prefs not exist");
        }
    }
    private void Counter()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Count++;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Count--;
        }
    }
    private void PrefsController()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SavePrefs();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            LoadPrefs();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            DeletePrefs();
        }
    }
    private void Update()
    {
        Counter();
        PrefsController();
    }
}
