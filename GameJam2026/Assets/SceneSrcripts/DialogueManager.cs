using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("UI элементы")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;
    public Image characterImage;

    [Header("Аудио")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    private DialogueData currentDialogue;
    private int currentIndex = 0;
    private bool isDialogueActive = false;

    // Вызывается для запуска диалога из 3D или скрипта
    public void StartDialogue(DialogueData data)
    {
        currentDialogue = data;
        currentIndex = 0;
        isDialogueActive = true;
        dialoguePanel.SetActive(true);

        DisplayCurrentLine();
    }
    [Header("Какой Акт запустить при старте игры?")]
    public DialogueData startingAct; // Ссылка на самый первый акт
    private void Awake()
    {
        // Если поле не перетащено вручную, ищем AudioSource на этом же GameObject
        if (sfxSource == null)
        {
            sfxSource = GetComponent<AudioSource>();

            // Если AudioSource всё ещё не найден, создаем его автоматически
            if (sfxSource == null)
            {
                sfxSource = gameObject.AddComponent<AudioSource>();
            }
        }
    }
    private void Start()
    {
        // Как только сцена загрузилась — запускаем первый акт
        if (startingAct != null)
        {
            StartDialogue(startingAct);
        }
        else
        {
            Debug.LogWarning("Забыли указать Starting Act в DialogueManager!");
        }
    }
    // Вызывается при КЛИКЕ по экрану
    public void OnClickNext()
    {
        if (!isDialogueActive) return;

        currentIndex++;

        if (currentIndex < currentDialogue.lines.Length)
        {
            DisplayCurrentLine();
        }
        else
        {
           // EndDialogue();
        }
    }

    private void DisplayCurrentLine()
    {
        DialogueLine line = currentDialogue.lines[currentIndex];

        // 1. Обновляем текст и имя
        speakerNameText.text = line.speakerName;
        dialogueText.text = line.text;

        // 2. Синхронизируем спрайт
        if (line.characterSprite != null)
        {
            characterImage.gameObject.SetActive(true);
            characterImage.sprite = line.characterSprite;
        }
        else
        {
            characterImage.gameObject.SetActive(false); // Скрываем, если никто не стоит
        }

        // 3. Воспроизводим SFX/Озвучку
        if (line.voiceOrSfx != null)
        {
            sfxSource.PlayOneShot(line.voiceOrSfx);
        }

        // 4. Переключаем фоновую музыку, если задан новый трек
        if (line.bgmClip != null && bgmSource.clip != line.bgmClip)
        {
            bgmSource.clip = line.bgmClip;
            bgmSource.Play();
        }
    }

    //private void EndDialogue()
    //{
       // isDialogueActive = false;

        // Смотрим, что прописано в текущем Акте в папке:
        //switch (currentDialogue.endAction)
        //{
           // case ActEndAction.GoToNextAct:
              //  if (currentDialogue.nextDialogue != null)
              //  {
                    // Запускаем следующий файл акта из папки
              //      StartDialogue(currentDialogue.nextDialogue);
              //  }
              //  break;

           // case ActEndAction.Start3DScene1:
             //   dialoguePanel.SetActive(false);
                // Вызываем включение первой 3D сцены
             //   GameManager.Instance.SwitchTo3DMode(1);
              //  break;
   
           // case ActEndAction.Start3DScene2:
              //  dialoguePanel.SetActive(false);
                // Вызываем включение второй 3D сцены
               // GameManager.Instance.SwitchTo3DMode(2);
               // break;

           // case ActEndAction.OpenChatbot:
                // Открываем окно чат-бота
              //  GameManager.Instance.OpenChatbotWindow();
              //  break;
      //  }
  //  }
}
