using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string speakerName;        // Имя говорящего
    [TextArea(3, 5)]
    public string text;               // Текст реплики
    public Sprite characterSprite;    // Спрайт персонажа (null, если никто не говорит)

    [Header("Аудио (необязательно)")]
    public AudioClip voiceOrSfx;      // Озвучка или эффект на этой строчке
    public AudioClip bgmClip;         // Музыка (если меняется на этой фразе)
}
