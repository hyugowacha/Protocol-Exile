using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBodyAim : MonoBehaviour
{
    public float verticalSpeed = 2.0f;   // ���콺 Y �ӵ�
    public float horizontalSpeed = 2.0f; // ���콺 X �ӵ�
    public float maxVerticalAngle = 45.0f; // ���� ���� ����
    public float maxHorizontalAngle = 60.0f; // �¿� ���� ����

    private float verticalAngle = 0.0f;   // ���� ���� ����
    private float horizontalAngle = 0.0f; // ���� �¿� ����

    void Update()
    {
        // ���콺 �Է�
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseX = Input.GetAxis("Mouse X");

        // �Է°����� ���� ����
        verticalAngle -= mouseY * verticalSpeed;    // ���콺 ���� �ø��� ��������
        horizontalAngle += mouseX * horizontalSpeed; // ���콺 ���������� �����̸� �������

        // ���� ���� (Clamp)
        verticalAngle = Mathf.Clamp(verticalAngle, -maxVerticalAngle, maxVerticalAngle);
        horizontalAngle = Mathf.Clamp(horizontalAngle, -maxHorizontalAngle, maxHorizontalAngle);

        // ȸ�� ���� (���� ȸ��)
        transform.localRotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f);
    }
}
