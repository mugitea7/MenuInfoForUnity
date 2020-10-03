using UnityEngine;

namespace Mugitea.MenuInfoPackage
{
    /// <summary>
    /// 簡易セーブ&ロード. データは1つのみしか対応できない.
    /// </summary>
    public class DataManageButton : MonoBehaviour
    {
        [SerializeField] private Player player = null;

        private const string PLAYERDATA = "data";

        public void SaveButton()
        {
            player.Save();
            SaveData.Save<Datas>(player.data, PLAYERDATA);
        }

        public void LoadButton()
        {
            var data = SaveData.Load<Datas>(PLAYERDATA);

            if (data == null)
                return;

            player.data = data;
            player.Load();
        }
    }
}