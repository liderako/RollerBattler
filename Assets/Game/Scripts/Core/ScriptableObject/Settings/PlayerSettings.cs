using UnityEngine;

namespace CoreGame.SO
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/Settings/PlayerSettings", order = 2)]
    public class PlayerSettings : ScriptableObject
    {
        public float SpeedMove;
        public float SpeedRotate;
    }
}