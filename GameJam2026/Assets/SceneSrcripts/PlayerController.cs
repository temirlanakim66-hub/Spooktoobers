using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Движение")]
    public float moveSpeed = 5f;
    public CharacterController controller;

    [Header("Камера")]
    public Transform playerCamera;
    public float mouseSensitivity = 2f;
    private float xRotation = 0f;

    [Header("Управление")]
    public bool isLookEnabled = true; // Включено ли вращение камеры

    void Start()
    {
        // Применяем начальные настройки курсора
        UpdateCursorState();
    }

    void Update()
    {
        // Проверяем нажатие ПКМ (1 - это правая кнопка мыши)
        if (Input.GetMouseButtonDown(1))
        {
            isLookEnabled = !isLookEnabled; // Переключаем значение на противоположное
            UpdateCursorState(); // Обновляем курсор
        }

        // --- Вращение камеры (работает, только если isLookEnabled = true) ---
        if (isLookEnabled)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            transform.Rotate(Vector3.up * mouseX);
        }

        // --- Движение (WASD) ---
        // Оставил вне условия, чтобы персонаж мог идти, даже когда вы двигаете курсором
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    // Метод для скрытия/показа курсора
    private void UpdateCursorState()
    {
        if (isLookEnabled)
        {
            Cursor.lockState = CursorLockMode.Locked; // Блокируем в центре
            Cursor.visible = false; // Прячем
        }
        else
        {
            Cursor.lockState = CursorLockMode.None; // Отпускаем курсор
            Cursor.visible = true; // Показываем
        }
    }

    // Для ползунка настроек
    public void SetSensitivity(float newSensitivity)
    {
        mouseSensitivity = newSensitivity;
    }
}