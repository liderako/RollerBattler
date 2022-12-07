using UnityEngine;

namespace CoreGame.SO
{
    [CreateAssetMenu(fileName = "ShopData", menuName = "ScriptableObjects/Shop/ShopData", order = 0)]
    public class ShopItem : ScriptableObject
    {
        public ShopItem[] shopItems;
    }
}