using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mugitea.MenuInfoPackage
{
    /// <summary>
    /// アイテムを表示
    /// </summary>
    public class DisplayItemElement : MonoBehaviour
    {
        [SerializeField] private ItemDescription itemDescription = null;
        [SerializeField] private Button button = null;
        [SerializeField] private Image itemImage = null;
        [SerializeField] private Text itemNumText = null;

        public void SetItemData(ItemData _itemData, int _num)
        {
            itemImage.sprite = _itemData.itemImage2D;
            itemNumText.text = _num.ToString();

            button.onClick.AddListener(
                () => itemDescription.SetItemData(_itemData)
            );

            SetDataColorsAlpha(1f);
        }

        private void OnDisable()
        {
            itemImage.sprite = null;
            itemNumText.text = "";

            SetDataColorsAlpha(0f);
        }

        private void SetDataColorsAlpha(float _value)
        {
            var itemImageColor = itemImage.color;
            var itemNumTextColor = itemNumText.color;

            itemImageColor.a = _value;
            itemNumTextColor.a = _value;

            itemImage.color = itemImageColor;
            itemNumText.color = itemNumTextColor;
        }
    }
}