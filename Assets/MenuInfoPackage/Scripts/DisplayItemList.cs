using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mugitea.MenuInfoPackage
{
    /// <summary>
    /// アイテムの表示(UI)
    /// </summary>
    public class DisplayItemList : MonoBehaviour
    {
        [SerializeField] private Player player = null;

        private void OnEnable()
        {
            DisplayItems();
        }

        private void DisplayItems()
        {
            int index = 0;
            foreach (Transform child in transform)
            {
                try
                {
                    child.GetComponent<DisplayItemElement>().SetItemData(player.data.itemPossessionDataList[index].itemData, player.data.itemPossessionDataList[index].itemNum);
                    index += 1;
                }
                catch
                {

                }
            }
        }
    }
}