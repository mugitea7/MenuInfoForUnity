using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mugitea.MenuInfoPackage
{
    /// <summary>
    /// アイテムの3Dモデルをドラッグで回転できるようにする.
    /// </summary>
    public class ItemModelRotationPanel : MonoBehaviour
    {
        [SerializeField] private GameObject itemModel = null;
        [SerializeField] private float rotationSpeed = 1f;

        /// <summary>
        /// これをEventTriggerのDragに突っ込む.
        /// </summary>
        public void DragRotation()
        {
            OnRotate(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
        }

        /// <summary>
        /// https://teratail.com/questions/147069
        /// より.
        /// </summary>
        /// <param name="delta"></param>
        void OnRotate(Vector2 delta)
        {
            float deltaAngle = delta.magnitude * rotationSpeed;

            if (Mathf.Approximately(deltaAngle, 0.0f))
            {
                return;
            }

            Transform cameraTransform = Camera.main.transform;
            Vector3 deltaWorld = cameraTransform.right * delta.x + cameraTransform.up * delta.y;

            Vector3 axisWorld = Vector3.Cross(deltaWorld, cameraTransform.forward).normalized;

            itemModel.transform.Rotate(axisWorld, deltaAngle, Space.World);
        }

    }
}