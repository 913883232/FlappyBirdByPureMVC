using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstConfig
{
    public const int BEHAV_LENGTH_L1 = 4;
    public const int BEHAV_LENGTH_L2 = 1;
    public const int BEHAV_LENGTH_L3 = 2;
    public const int BEHAV_LENGTH_L4 = 3;

    //Attributes
    public const string _checkState = "checkState";
    public const string _changeState = "changeState";
    public const string _checkCharacterTitle = "checkCharacterTitle";
    public const string _arrived = "arrived";
    public const string _move = "move";
    public const string _stateTime = "stateTime";
    public const string _checkLandState = "checkLandState";
    public const string _random = "random";
    public const string _case = "case";

    public const string _animation = "animation";
    public const string _weaponState = "weaponState";
    public const string _handleItem = "handleItem";


    //names
    public const string _main = "main";
    public const string _name = "name";
    public const string _position = "position";
    public const string _greaterThan = "greaterThan";
    public const string _weight = "weight";


    public static string[] attributeNames_L1 = new string[] { "checkCharacterTitle", "arrived", "checkLandState", "stateTime" };
    public static string[] attributeNames_L2 = new string[] { "random" };
    public static string[] attributeNames_L3 = new string[] { "case", "setHoeingState" };
    public static string[] attributeNames_L4 = new string[] { "animation", "weaponState", "handleItem" };
    //Enums
    public enum Enum_WeaponName
    {
        dingpa = 1,
        fazhang,
        gongjian_1,
        gongjiang_2,
        hammer,
        hatchet,
        jian
    }

    
}
