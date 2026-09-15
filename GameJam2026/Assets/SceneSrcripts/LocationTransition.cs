using UnityEngine;

public class LocationTransition : MonoBehaviour
{
    [Header("Камера игрока")]
    public Transform playerCamera;

    [Header("Настройки места назначения")]
    public Transform targetPoint; // 3D-точка, куда переместится камера
    public GameObject targetUI;   // Папка со стрелками НОВОЙ локации, которую надо включить

    [Header("Настройки текущего места")]
    public GameObject currentUI;  // Папка со стрелками ТЕКУЩЕЙ локации, которую надо выключить

    // Эту функцию мы будем вызывать при нажатии на кнопку
    public void GoToLocation()
    {
        // 1. Перемещаем камеру
        if (playerCamera != null && targetPoint != null)
        {
            playerCamera.position = targetPoint.position;
            playerCamera.rotation = targetPoint.rotation;
        }

        // 2. Включаем интерфейс новой локации (показываем новые стрелки)
        if (targetUI != null)
        {
            targetUI.SetActive(true);
        }

        // 3. Выключаем интерфейс старой локации (прячем текущие стрелки)
        if (currentUI != null)
        {
            currentUI.SetActive(false);
        }
    }
}