using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.SO
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "ScriptableObjects/Settings/LevelSettings", order = 1)]
    public class LevelSettings : ScriptableObject
    {
        public string[] levelsName;
        public int minNumberLevel;
        public int maxNumberLevel;
    }
}