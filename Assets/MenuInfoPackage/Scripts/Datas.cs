using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mugitea.MenuInfoPackage
{
    /// <summary>
    /// Playerのデータ.
    /// </summary>
    [Serializable]
    public class Datas
    {
        public Vector3 location = new Vector3();
        public List<bool> flags = new List<bool>();
        public float playTime = 0f;

        public string GetPlayTime()
        {
            int playTime_seconds = (int)playTime;

            var span = new TimeSpan(0, 0, playTime_seconds);

            return span.ToString(@"hh\:mm\:ss");
        }

        #region 所持アイテムリスト・アイテムリスト操作
        [Serializable]
        public class ItemPossessionDataList
        {
            public ItemData itemData;
            public int itemNum;

            public ItemPossessionDataList(ItemData _itemData, int _itemNum)
            {
                itemData = _itemData;
                itemNum = _itemNum;
            }
        }

        public List<ItemPossessionDataList> itemPossessionDataList = new List<ItemPossessionDataList>();

        public bool isExistsItem(ItemData _itemData)
        {
            foreach (ItemPossessionDataList dataList in itemPossessionDataList)
            {
                if (dataList.itemData == _itemData) return true;
            }
            return false;
        }

        public void GetItem(ItemData _itemData, int _value)
        {
            if (!isExistsItem(_itemData))
            {
                itemPossessionDataList.Add(new ItemPossessionDataList(_itemData, _value));
                return;
            }

            foreach (ItemPossessionDataList dataList in itemPossessionDataList)
            {
                dataList.itemNum += _value;
            }

            for (int index = 0; index < itemPossessionDataList.Count; index++)
            {
                if (itemPossessionDataList[index].itemData != _itemData) continue;

                itemPossessionDataList[index].itemNum += _value;
            }

        }

        public void ReleaseItem(ItemData _itemData, int _value)
        {
            if (!isExistsItem(_itemData))
            {
                Debug.LogWarning("アイテムデータが存在しません.");
                return;
            }

            for (int index = 0; index < itemPossessionDataList.Count; index++)
            {
                if (itemPossessionDataList[index].itemData != _itemData) continue;

                itemPossessionDataList[index].itemNum -= _value;
                if (itemPossessionDataList[index].itemNum <= 0)
                    itemPossessionDataList.RemoveAt(index);
            }
        }
        #endregion
    }
}