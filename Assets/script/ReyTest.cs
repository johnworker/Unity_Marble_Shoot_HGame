using UnityEngine;
using System.Collections;

namespace LEO
{
    public class RayTest : MonoBehaviour
    {
        public Transform startPos;//起點位置
        public Transform finalPos;//終點位置
        void Update()
        {
            // (finalPos.position - startPos.position) 終點位置減去 起點位置 等於方向向量
            Ray ray = new Ray(startPos.position, (finalPos.position - startPos.position));
            // 輸出檢測
            print(ray);
        }
    }
}