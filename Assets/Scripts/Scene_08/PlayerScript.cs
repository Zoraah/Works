using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private UnityEvent VisualCastSkillEvent;

    public delegate void CastSkillCallback(string message);
    public event CastSkillCallback CastSecondDebugEvent;
    private event CastSkillCallback CastFirstSkillDebugEvent;
    
    private void Start()
    {
        CastFirstSkillDebugEvent += Debug.Log;
    }
    private void Update()
    {
        PlayerControl();
    }
    protected void PlayerControl()
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
