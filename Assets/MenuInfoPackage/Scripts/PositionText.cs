using UnityEngine;
using UnityEngine.UI;

namespace Mugitea.MenuInfoPackage
{
    /// <summary>
    /// PlayerのtransformをTextに表示するだけ.テスト用.
    /// </summary>
    public class PositionText : MonoBehaviour
    {
        private Text text;
        [SerializeField] private Player player = null;

        void Start()
        {
            text = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            try
            {
                text.text = "PlayerPos: " + player.transform.position + "\n" + "DataPos: " + SaveData.Load<Datas>("data").location + "\n";
            }
            catch
            {
                text.text = "PlayerPos: " + player.transform.position + "\n" + "DataPos: " + Vector3.zero + "\n";
            }

            
        }
    }
}