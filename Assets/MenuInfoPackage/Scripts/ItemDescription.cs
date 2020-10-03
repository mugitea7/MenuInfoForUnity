using UnityEngine;
using UnityEngine.UI;

namespace Mugitea.MenuInfoPackage
{
    /// <summary>
    /// アイテムの説明.
    /// </summary>
    public class ItemDescription : MonoBehaviour
    {
        [SerializeField] private Text itemNameText = null;
        [SerializeField] private Text itemDescriptionText = null;
        [SerializeField] private GameObject itemModel = null;

        private Quaternion firstRotation;
        private MeshFilter meshFilter;

        /// <summary>
        /// アイテムデータのセット.
        /// </summary>
        /// <param name="_itemData"></param>
        public void SetItemData(ItemData _itemData)
        {
            itemNameText.text = _itemData.itemName;
            itemDescriptionText.text = _itemData.itemDescription;
            meshFilter.mesh = _itemData.itemImage3D;
            itemModel.transform.rotation = firstRotation;

            SetDataColorsAlpha(1f);
        }

        private void OnEnable()
        {
            itemNameText.text = "";
            itemDescriptionText.text = "";
            firstRotation = itemModel.transform.rotation;

            try
            {
                meshFilter.mesh = null;
            }
            catch
            {
                meshFilter = itemModel.GetComponent<MeshFilter>();
                meshFilter.mesh = null;
            }

            SetDataColorsAlpha(0f);
        }

        /// <summary>
        /// Alpha値を設定する.
        /// </summary>
        /// <param name="_value"></param>
        private void SetDataColorsAlpha(float _value)
        {
            var itemImageColor = itemNameText.color;
            var itemNumTextColor = itemDescriptionText.color;

            itemImageColor.a = _value;
            itemNumTextColor.a = _value;

            itemNameText.color = itemImageColor;
            itemDescriptionText.color = itemNumTextColor;
        }
    }
}