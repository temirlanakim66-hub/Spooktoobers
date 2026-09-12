using UnityEngine;

public enum ActEndAction
{
    GoToNextAct,    // Просто следующий текст новеллы
    Start3DScene1,  // Переход в первую 3D-комнату
    Start3DScene2,  // Переход во вторую 3D-комнату
    OpenChatbot     // Вызов чат-бота
}

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue System/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public DialogueLine[] lines; // Массив фраз этого акта

    [Header("Что делать после завершения этого Акта?")]
    public ActEndAction endAction;

    // Поле нужно, только если endAction == GoToNextAct
    public DialogueData nextDialogue;
}