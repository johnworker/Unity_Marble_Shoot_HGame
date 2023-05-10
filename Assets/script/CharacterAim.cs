using UnityEngine;

namespace LEO
{
    public class CharacterAim : MonoBehaviour
    {
        [SerializeField] private float rotateSpeed = 10f;
        [SerializeField] private float maxAngle = 60f;

        public float maxDistance = 100f;
        public LineRenderer lineRenderer;

        public Color lineColor = Color.red;
        public float lineWidth = 5f;
        private void Start()
        {
            // 獲取 LineRenderer 組件的引用
            lineRenderer = GetComponent<LineRenderer>();

            // 設置線條的顏色和寬度
            lineRenderer.startColor = lineColor;
            lineRenderer.endColor = lineColor;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
        }

        void Update()
        {
            
            // 獲取鼠標輸入
            float horizontalInput = Input.GetAxis("Mouse X");
            float verticalInput = Input.GetAxis("Mouse Y");

            
            // 計算射線方向
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            
            // 檢測射線是否碰撞
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // 計算角度
                Vector3 lookAtPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                Vector3 direction = lookAtPoint - transform.position;
                float angle = Vector3.Angle(direction, transform.forward);

                // 限制角度
                angle = Mathf.Clamp(angle, -maxAngle, maxAngle);

                // 旋轉角色
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            }
            


            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                lineRenderer.SetPositions(new Vector3[] { transform.position, hit.point });
            }
            else
            {
                lineRenderer.SetPositions(new Vector3[] { transform.position, transform.position + transform.forward * maxDistance });
            }
        }
    }
}