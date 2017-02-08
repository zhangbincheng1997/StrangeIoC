using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class AudioEditor : EditorWindow
{
    private static string savePath = "Assets/Framework/Resources/AudioInfo.txt";

    [MenuItem("Manager/AudioManager")]
    public static void CreateWindow()
    {
        AudioEditor window = GetWindow<AudioEditor>("音效管理");
        window.Show();
    }

    private string audioName;
    private string audioPath;
    private Dictionary<string, string> audioDict = new Dictionary<string, string>();

    void Awake()
    {
        LoadAudioInfo();
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("音效名字");
        GUILayout.Label("音效路径");
        GUILayout.EndHorizontal();

        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            GUILayout.BeginHorizontal();
            GUILayout.Label(key);
            GUILayout.Label(value);

            if (GUILayout.Button("删除"))
            {
                audioDict.Remove(key);
                SaveAudioInfo();
                LoadAudioInfo();
                return;
            }

            GUILayout.EndHorizontal();
        }

        audioName = EditorGUILayout.TextField("音效名字", audioName);
        audioPath = EditorGUILayout.TextField("音效路径", audioPath);
        if (GUILayout.Button("添加音效"))
        {
            object obj = Resources.Load(audioPath);
            if (obj == null)
            {
                Debug.LogWarning("音效不存在");
                audioPath = "";
            }
            else
            {
                if (audioDict.ContainsKey(audioName))
                {
                    Debug.LogWarning("音效已存在");
                }
                else
                {
                    audioDict.Add(audioName, audioPath);
                    SaveAudioInfo();
                    LoadAudioInfo();
                }
            }
        }
    }

    private void SaveAudioInfo()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            sb.Append(key + "," + value + "\n");
        }
        File.WriteAllText(savePath, sb.ToString());
    }

    private void LoadAudioInfo()
    {
        if (File.Exists(savePath))
        {
            audioDict.Clear();
            string[] lines = File.ReadAllLines(savePath);
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    string[] pro = line.Split(',');
                    audioDict.Add(pro[0], pro[1]);
                }
            }
        }
    }
}
