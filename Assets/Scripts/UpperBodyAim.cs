using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBodyAim : MonoBehaviour
{
    public float verticalSpeed = 2.0f;   // 마우스 Y 속도
    public float horizontalSpeed = 2.0f; // 마우스 X 속도
    public float maxVerticalAngle = 45.0f; // 상하 조준 제한
    public float maxHorizontalAngle = 60.0f; // 좌우 조준 제한

    private float verticalAngle = 0.0f;   // 현재 상하 각도
    private float horizontalAngle = 0.0f; // 현재 좌우 각도

    void Update()
    {
        // 마우스 입력
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseX = Input.GetAxis("Mouse X");

        // 입력값으로 각도 변경
        verticalAngle -= mouseY * verticalSpeed;    // 마우스 위로 올리면 음수방향
        horizontalAngle += mouseX * horizontalSpeed; // 마우스 오른쪽으로 움직이면 양수방향

        // 각도 제한 (Clamp)
        verticalAngle = Mathf.Clamp(verticalAngle, -maxVerticalAngle, maxVerticalAngle);
        horizontalAngle = Mathf.Clamp(horizontalAngle, -maxHorizontalAngle, maxHorizontalAngle);

        // 회전 적용 (로컬 회전)
        transform.localRotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f);
    }
}
