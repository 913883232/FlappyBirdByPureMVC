using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SecondWindow : EditorWindow
{
    private string[] animations = new string[] { "idle", "rest", "sleep", "build", "cutTree", "quarry", "hoeing", "seed", "watering", "harvest", "hunt", "archery", "cutMeat", "sideCarry", "forwardCarry", "topCarry", "notCarry" };
    private string[] weaponName = new string[] { "dingpa", "fazhang", "gongjian_1", "gongjian_2", "hammer", "hatchet", "jian", "dao", "gong", "kuangchu", "liaodao", "tong" };
    private string[] interiorAnimations = new string[] { "idle", "rest", "sleep" };
    //枚举列表
    private List<string[]> options = new List<string[]>();


    private TempData tempData = null;

    private int index = 0;
    private int[] namesInt = new int[ConstConfig.BEHAV_LENGTH_L4 - 1];
    private void Awake()
    {
        tempData = AssetDatabase.LoadAssetAtPath<TempData>("Assets/Plugins/MyPlugin/Data/TempData.asset");
        index = tempData.curStateIndex;

        namesInt = tempData.behaviours[index].indexs;

        options.Add(animations);
        options.Add(weaponName);
    }
    private void OnGUI()
    {
        //绘制一级标签
        for (int i = 0; i < ConstConfig.BEHAV_LENGTH_L3; i++)
        {
            GUILayout.BeginHorizontal();
            tempData.behaviours[index].toggles_LevelFirst[i] = EditorGUILayout.Toggle(ConstConfig.attributeNames_L1[i], tempData.behaviours[index].toggles_LevelFirst[i]);
            if (tempData.behaviours[index].toggles_LevelFirst[i])
            {

            }
            GUILayout.EndHorizontal();
        }
        //绘制二级标签

        //绘制三级标签

        //绘制四级标签
        for (int i = 0; i < ConstConfig.BEHAV_LENGTH_L4 - 1; i++)
        {
            GUILayout.BeginHorizontal();
            tempData.behaviours[index].toggles_LevelFourth[i] = EditorGUILayout.Toggle(ConstConfig.attributeNames_L4[i], tempData.behaviours[index].toggles_LevelFourth[i]);
            if (tempData.behaviours[index].toggles_LevelFourth[i])
            {
                namesInt[i] = EditorGUILayout.Popup(namesInt[i], options[i]);
                tempData.behaviours[index].indexs[i] = namesInt[i];
                tempData.behaviours[index].names[i] = options[i][namesInt[i]];
            }
            GUILayout.EndHorizontal();
        }
        for (int i = ConstConfig.BEHAV_LENGTH_L4 - 1; i < ConstConfig.BEHAV_LENGTH_L4; i++)
        {
            GUILayout.BeginHorizontal();
            tempData.behaviours[index].toggles_LevelFourth[i] = EditorGUILayout.Toggle(ConstConfig.attributeNames_L4[i], tempData.behaviours[index].toggles_LevelFourth[i]);
            if (tempData.behaviours[index].toggles_LevelFourth[i])
            {
                tempData.behaviours[index].names[i] = GUILayout.TextField(tempData.behaviours[index].names[i], EditorStyles.textField);
            }
            GUILayout.EndHorizontal();
        }


        if (GUILayout.Button("确定"))
        {
            AssetDatabase.Refresh();
            this.Close();
        }
    }
}
