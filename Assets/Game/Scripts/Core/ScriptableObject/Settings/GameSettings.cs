using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.SO
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/Settings/GameSettings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        public LevelSettings LevelSettings;
        public PlayerSettings PlayerSettings;
    }
}
