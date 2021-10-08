using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Networking;
using UnityEngine;

public class WebRequestScript : MonoBehaviour
{
    private AudioSource _audioSource;
    private string _path;
    [SerializeField]
    [TextArea(1, 6)]
    private string _data;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        StartCoroutine(GetJsonFile());
        StartCoroutine(GetTexture());
        StartCoroutine(DownloadFile());
        StartCoroutine(GetAudioClip());
    }
    private void Update()
    {
        PutOnServer();
        GetFromServer();
    }

    private void GetFromServer()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(GetJsonFile());
        }
    }
    private void PutOnServer()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(PutJsonFile());
        }
    }
    private struct PostStruct
    {
        public int id;
        public int userId;
        public string title;
        public string body;
    }
    private IEnumerator GetJsonFile()
    {
        UnityWebRequest uwr = UnityWebRequest.Get("https://jsonplaceholder.typicode.com/posts/34");
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error of finding json information in web request");
        }
        else
        {
            _data = uwr.downloadHandler.text;
            _path = Path.Combine(Application.streamingAssetsPath, "JsonData.json");
            File.WriteAllText(_path, _data);
            Debug.Log("Json information finded successfully");
        }
    }
    private IEnumerator PutJsonFile()
    {
        PostStruct post = new PostStruct()
        {
            id = 34,
            userId = 123,
            title = "Updated Title",
            body = "Updated Body"
        };
        _data = JsonUtility.ToJson(post);
        UnityWebRequest uwr = UnityWebRequest.Put("https://jsonplaceholder.typicode.com/posts/34", _data);
        uwr.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error of putting json data on server");
        }
        else
        {
            Debug.Log("Json data putted successfully");
            post = JsonUtility.FromJson<PostStruct>(uwr.downloadHandler.text);
            _data = JsonUtility.ToJson(post);
        }
    }
    private IEnumerator GetTexture()
    {
        UnityWebRequest uwr = new UnityWebRequest("https://bit.ly/3Dq4Lu2");
        DownloadHandlerTexture texDh = new DownloadHandlerTexture(true);
        uwr.downloadHandler = texDh;
        yield return uwr.SendWebRequest();
        if(uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error of texture web request");
        }
        else
        {
            Texture tex = texDh.texture;
            GetComponent<MeshRenderer>().material.mainTexture = tex;
            Debug.Log("Texture successfully setted");
        }
    }
    private IEnumerator DownloadFile()
    {
        UnityWebRequest uwr = new UnityWebRequest("https://fs34.fex.net/download/3654245137", UnityWebRequest.kHttpVerbGET);
        string path = Path.Combine(Application.streamingAssetsPath, "Data.json");
        uwr.downloadHandler = new DownloadHandlerFile(path);
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error of file web request");
        }
        else
        {
            Debug.Log("File successfully downloaded and saved to: " + path);
        }
    }
    private IEnumerator GetAudioClip()
    {
        var uwr = UnityWebRequestMultimedia.GetAudioClip("https://bit.ly/3uUFo09", AudioType.MPEG);
        yield return uwr.SendWebRequest();
        if(uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error of audio clip web request");
        }
        else
        {
            AudioClip _clip = DownloadHandlerAudioClip.GetContent(uwr);
            _audioSource.clip = _clip;
            _audioSource.Play();
            Debug.Log("AudioClip successfully setted");
        }

    }
}
