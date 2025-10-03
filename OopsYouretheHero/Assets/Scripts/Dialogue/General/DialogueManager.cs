using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    Message[] currentMessage;
    Actor[] currentActors;
    int activeMessage = 0;

    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessage = messages;
        currentActors = actors;
        activeMessage = 0;

        isActive = true;


        backgroundBox.transform.localScale = Vector3.one;

        Debug.Log("Started Conversation. Loded messages: " + messages.Length);

        DisplayMessage();
        AudioManager.instance.PlayOneShot(FMODEvents.instance.dialoguePop, this.transform.position);
    }

    public void CloseDialogue(Message[] messages, Actor[] actors)
    {
       currentMessage = messages;
       currentActors = actors;
        activeMessage = 0;

        isActive = false;


        backgroundBox.transform.localScale = Vector3.zero;

      //  Debug.Log("Started Conversation. Loded messages: " + messages.Length);

       // DisplayMessage();
    }



    void DisplayMessage()
    {
       Message messageToDisplay = currentMessage[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actortoDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actortoDisplay.name;
        actorImage.sprite = actortoDisplay.sprite;

    }

    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage < currentMessage.Length)
        {
            DisplayMessage();
            AudioManager.instance.PlayOneShot(FMODEvents.instance.dialoguePop, this.transform.position);
        }
        else
        {
            Debug.Log("conversation ended");
            isActive = false;

            backgroundBox.transform.localScale = Vector3.zero;
        }



    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && isActive == true)
        {
            NextMessage();
            AudioManager.instance.PlayOneShot(FMODEvents.instance.dialoguePop, this.transform.position);
        }
    }
}
