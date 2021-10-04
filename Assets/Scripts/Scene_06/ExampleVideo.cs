using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class ExampleVideo : MonoBehaviour
{
    private UnityEngine.Video.VideoPlayer _videoPlayer;
    private string status;
    private void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        _videoPlayer = cam.AddComponent<UnityEngine.Video.VideoPlayer>();
        _videoPlayer.url = Path.Combine(Application.streamingAssetsPath, "RenderingAt5am.mp4");
        _videoPlayer.isLooping = true;
        _videoPlayer.Pause();
        status = "Press to play";
    }
    private void OnGUI()
    {
        GUIStyle buttonWidth = new GUIStyle(GUI.skin.GetStyle("button"));
        buttonWidth.fontSize = 18 * (Screen.width / 800);
        if(GUI.Button(new Rect(Screen.width / 16, Screen.height / 16, Screen.width / 3, Screen.height / 8), status, buttonWidth))
        {
            if(_videoPlayer.isPlaying)
            {
                _videoPlayer.Pause();
                status = "Press to play";
            }
            else
            {
                _videoPlayer.Play();
                status = "Press to pause";
            }
        }
    }
    private void Update()
    {
        
    }
}
