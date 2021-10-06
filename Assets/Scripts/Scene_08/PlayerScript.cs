using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    public delegate void CastSkillCallback(string message);
    private event CastSkillCallback CastFirstSkillDebugEvent;
    public event CastSkillCallback CastSecondDebugEvent;

    [SerializeField]
    private UnityEvent VisualCastSkillEvent;
    
    [SerializeField]
    private GameObject _bullet;
    private void Start()
    {
        CastFirstSkillDebugEvent += Debug.Log;
    }
    private void Update()
    {
        PlayerControl();
    }
    private void PlayerControl()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CastFirstSkillDebugEvent?.Invoke("Q skill cast");
            VisualCastSkillEvent?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            CastSecondDebugEvent?.Invoke("W skill cast");
            VisualCastSkillEvent?.Invoke();
        }
    }
}
