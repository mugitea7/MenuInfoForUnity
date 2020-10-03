using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mugitea.MenuInfoPackage
{
    /// <summary>
    /// UIを横並びにして遷移できる. BoW的な感じにもできる(やろうと思えば).
    /// </summary>
    public class MenuParentManager : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private AnimationCurve moveCurve = new AnimationCurve();

        private List<Vector2> childPositions = new List<Vector2>();
        private int nowDisplayIndex = 0;
        private float time = 0f;
        private Coroutine moveCoroutine = null;

        private void Awake()
        {
            StartCoroutine(AssignmentChildTransforms());
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                MoveElementsNext();
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                MoveElementsPrev();

        }

        private void OnDisable()
        {
            nowDisplayIndex = 0;
        }

        /// <summary>
        /// indexまで画面を移動させる.
        /// </summary>
        /// <param name="_index"></param>
        /// <param name="_transform"></param>
        /// <returns></returns>
        private IEnumerator Move(int _index)
        {
            if (_index < 0)
                _index = 0;
            else if (childPositions.Count <= _index)
                _index = childPositions.Count - 1;

            time = 0f;
            nowDisplayIndex = _index;
            Vector2 _transform = transform.localPosition;


            while ((Vector2)transform.localPosition != childPositions[_index])
            {
                transform.localPosition = Vector2.Lerp(_transform, childPositions[_index], moveCurve.Evaluate(time * moveSpeed));
                time += Time.deltaTime;
                yield return null;
            }
        }

        /// <summary>
        /// indexまで移動.
        /// </summary>
        /// <param name="_index"></param>
        public void MoveElements(int _index)
        {
            if (_index < 0 || childPositions.Count - 1 < _index)
                return;

            if (moveCoroutine != null)
                StopCoroutine(moveCoroutine);

            moveCoroutine = StartCoroutine(Move(_index));
        }

        /// <summary>
        /// 次の要素へ移動.
        /// </summary>
        public void MoveElementsNext()
        {
            MoveElements(nowDisplayIndex + 1);
        }

        /// <summary>
        /// 前の要素へ移動.
        /// </summary>
        public void MoveElementsPrev()
        {
            MoveElements(nowDisplayIndex - 1);
        }

        /// <summary>
        /// 子のTransformを全てAdd.
        /// </summary>
        /// <returns></returns>
        private IEnumerator AssignmentChildTransforms()
        {
            yield return new WaitForEndOfFrame();
            foreach (RectTransform childTransform in transform)
            {
                childPositions.Add(childTransform.localPosition * -1);
            }
        }
    }
}