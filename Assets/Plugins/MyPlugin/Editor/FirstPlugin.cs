using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml;
using System.IO;

public class FirstPlugin : EditorWindow
{
    //临时存储
    private Dictionary<int, int> tempDict = new Dictionary<int, int>();
    //记录主行为
    private List<int> mainStates = new List<int>();
    //记录跳转行为
    private List<int> changeStates = new List<int>();

    private TempData tempData = null;

    private int index = 0;
    private string xmlName = null;
    private bool button = false;
    static float x = 0;
    static float y = 0;

    [MenuItem("AIXml/CreateAIXml")]
    static void Init()
    {
        FirstPlugin window = (FirstPlugin)EditorWindow.GetWindow(typeof(FirstPlugin), true, "主行为编辑");
        x = (float)1500;
        y = (float)Screen.height / 2;
        window.position = new Rect(x, y, 322f, 544f);
        window.Show();
    }
    private void Awake()
    {
        //Debug.LogFormat("窗口初始化时调用");
        tempData = AssetDatabase.LoadAssetAtPath<TempData>("Assets/Plugins/MyPlugin/Data/TempData.asset");
    }
    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("BehaviourName", EditorStyles.boldLabel);
        xmlName = GUILayout.TextField(xmlName, EditorStyles.textField);
        GUILayout.EndHorizontal();

        for (int i = 0; i < mainStates.Count; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("MainStep" + (i), EditorStyles.boldLabel);
            button = GUILayout.Button("点击编辑");
            GUILayout.Label("跳转至-->");
            tempDict[i] = int.Parse(GUILayout.TextField(tempDict[i].ToString(), EditorStyles.textField));
            changeStates[i] = tempDict[i];
            GUILayout.EndHorizontal();
            if (button)
            {
                tempData.curStateIndex = i;
                SecondWindow window = (SecondWindow)EditorWindow.GetWindow(typeof(SecondWindow), true, "具体行为编辑", true);
                window.position = new Rect(x, y, 322f, 544f);
                window.Show();
            }
        }

        if (GUILayout.Button("添加行为"))
        {
            AddMainStep();
        }
        if (GUILayout.Button("删除行为"))
        {
            RemoveMainStep();
        }
        if (GUILayout.Button("生成Xml"))
        {
            CreateXml();
        }
        if (GUILayout.Button("初始化"))
        {
            ResetAll();
        }
    }
    void AddMainStep()
    {
        tempDict.Add(index, 0);
        index++;
        changeStates.Add(index);
        mainStates.Add(index);
        Behaviour behaviour = new Behaviour();
        tempData.behaviours.Add(behaviour);
    }
    void RemoveMainStep()
    {
        index--;
        if (index < 0)
        {
            index = 0;
            return;
        }
        tempDict.Remove(index);
        changeStates.RemoveAt(index);
        mainStates.RemoveAt(index);
        tempData.behaviours.RemoveAt(index);
    }
    void CreateXml()
    {
        if (null == xmlName)
        {
            Debug.Log("请输入文件名");
        }
        else
        {
            Debug.LogFormat("生成" + xmlName + ".xml");
            WriteXml();
        }
    }
    void ResetAll()
    {
        index = 0;
        tempDict.Clear();
        mainStates.Clear();
        changeStates.Clear();
        tempData.behaviours.Clear();
    }
    void WriteXml()
    {
        string xmlPath = Path.Combine(Application.dataPath, "Plugins/MyPlugin/Data/" + xmlName + ".xml");
        if (File.Exists(xmlPath))
        {
            File.Delete(xmlPath);
        }
        //创建XmlDocument
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement root = xmlDoc.CreateElement("root");
        xmlDoc.AppendChild(root);


        for (int i = 0; i < tempDict.Count; i++)
        {
            bool[] toggles_LevelFourth = tempData.behaviours[i].toggles_LevelFourth;
            XmlElement group = xmlDoc.CreateElement(ConstConfig._checkState);
            group.SetAttribute("main", (i + 1).ToString());

            for (int j = 0; j < toggles_LevelFourth.Length; j++)
            {
                if (toggles_LevelFourth[j])
                {
                    XmlElement tempElement = xmlDoc.CreateElement(ConstConfig.attributeNames_L4[j]);
                    tempElement.SetAttribute(ConstConfig._name, tempData.behaviours[i].names[j]);
                    group.AppendChild(tempElement);
                }
            }

            XmlElement changeStep = xmlDoc.CreateElement(ConstConfig._changeState);
            changeStep.SetAttribute(ConstConfig._name, changeStates[i].ToString());

            group.AppendChild(changeStep);

            root.AppendChild(group);
        }
        xmlDoc.Save(xmlPath);
        AssetDatabase.Refresh();
    }
    private void OnDestroy()
    {
        //Debug.LogFormat("窗口销毁时调用");
        ResetAll();
        AssetDatabase.Refresh();
    }
    private void OnFocus()
    {
        //Debug.LogFormat("窗口拥有焦点时调用");
    }
    private void OnHierarchyChange()
    {
        //Debug.LogFormat("Hierarchy 视图发生改变时调用");
    }
    private void OnInspectorUpdate()
    {
        //Debug.LogFormat("Inspector 每帧更新");
    }
    private void OnLostFocus()
    {
        //Debug.LogFormat("失去焦点");
    }
    private void OnProjectChange()
    {
        //Debug.LogFormat("Project 视图发生改变时调用");
    }
    private void OnSelectionChange()
    {
        //Debug.LogFormat("在 hierarchy 或者 Project 视图中选择一个对象时调用");
    }
    private void Update()
    {
        //Debug.LogFormat("每帧更新");
    }
}
