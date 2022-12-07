using UnityEngine;

namespace CoreGame.SO
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "ScriptableObjects/Settings/EnemySettings", order = 3)]
    public class EnemySettings : ScriptableObject
    {
        public float SpeedMove;
        public float SpeedRotate;
    }
}