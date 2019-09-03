using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TempData : ScriptableObject
{
    public int curStateIndex;
    [SerializeField]
    public List<Behaviour> behaviours;
}

[System.Serializable]
public class Behaviour
{
    public bool[] toggles_LevelFirst = new bool[ConstConfig.BEHAV_LENGTH_L1];
    public bool[] toggles_LevelSecond = new bool[ConstConfig.BEHAV_LENGTH_L2];
    public bool[] toggles_LevelThird = new bool[ConstConfig.BEHAV_LENGTH_L3];
    public bool[] toggles_LevelFourth = new bool[ConstConfig.BEHAV_LENGTH_L4];

    public int[] indexs = new int[ConstConfig.BEHAV_LENGTH_L4 - 1];
    public string[] names = new string[ConstConfig.BEHAV_LENGTH_L4];
}
