using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mugitea.MenuInfoPackage
{
    /// <summary>
    /// Player用のクラス.
    /// </summary>
    public class Player : MonoBehaviour
    {
        public Datas data;

        private void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            transform.position += new Vector3(h, v, 0f);

            data.playTime += Time.deltaTime;
        }

        public void Save()
        {
            data.location = transform.position;
        }

        public void Load()
        {
            transform.position = data.location;
        }
    }
}