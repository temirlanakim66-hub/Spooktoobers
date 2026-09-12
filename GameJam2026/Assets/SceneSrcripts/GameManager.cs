using UnityEngine;

public enum GameState
{
    FreeRoam3D, // Режим от 1-го лица
    Dialogue,   // 2D визуальная новелла
    Chatbot     // Окно чат-бота
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentState { get; private set; }

    [Header("Контроллеры")]
    //public PlayerController3D playerController; // Скрипт ходьбы/камеры 3D
    public DialogueManager dialogueManager;

    private void Awake() => Instance = this;

    public void SetState(GameState newState)
    {
        CurrentState = newState;

        switch (newState)
        {
            case GameState.FreeRoam3D:
                //playerController.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;

            case GameState.Dialogue:
                //playerController.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;

            case GameState.Chatbot:
                //playerController.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
        }
    }
}
