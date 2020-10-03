using UnityEngine;

namespace Mugitea.MenuInfoPackage
{
    [CreateAssetMenu(menuName = "ManuInfoPackage/ItemData")]
    public class ItemData : ScriptableObject
    {
        public string itemName;
        public Sprite itemImage2D;
        public Mesh itemImage3D;
        [Multiline] public string itemDescription;
        //public int maxNum = 99;
    }
}