using UnityEngine;
using UnityEngine.UI;

namespace Mugitea.MenuInfoPackage
{
    //複数のセーブデータに対応.
    public class MultipleSaveDataManager : MonoBehaviour
    {
        [SerializeField] private Player player = null;
        [SerializeField] private string DataKey = "";
        [SerializeField] private Text playTimeText = null;

        private Datas datas = null;

        private void OnEnable()
        {
            Initialized();
        }

        /// <summary>
        /// 表示を初期化.
        /// </summary>
        private void Initialized()
        {
            datas = SaveData.Load<Datas>(DataKey);

            if (datas == null)
                playTimeText.text = "\nNo Data";
            else
                playTimeText.text = "\n" + datas.GetPlayTime();
        }

        /// <summary>
        /// データのセーブ.
        /// </summary>
        public void Save()
        {
            SaveData.Save(player.data, DataKey);
            Initialized();
        }

        /// <summary>
        /// データのロード.
        /// </summary>
        public void Load()
        {
            if (datas == null)
                return;

            player.data = datas;
            Initialized();
        }
    }
}
