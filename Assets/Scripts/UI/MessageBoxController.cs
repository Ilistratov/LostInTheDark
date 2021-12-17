using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBoxController : MonoBehaviour
{
    public struct Message
	{
        public Message(string message, float duration)
		{
            text = message;
            displayDuration = duration;
		}

        public string text;
        public float displayDuration;
	}

    TextBoxController textBox;
    Queue<Message> messageQueue;
    UnityEngine.UI.Text hintText;
    float nextMessageDisplayT;

    public void EnqueueMessage(Message message)
	{
        messageQueue.Enqueue(message);
    }

    void Start()
    {
        textBox = GetComponent<TextBoxController>();
        hintText = transform.Find("Hint Text").GetComponent<UnityEngine.UI.Text>();
        messageQueue = new Queue<Message>();
    }

    void ShowNextMessage()
	{
        textBox.Hide();
        hintText.enabled = false;
        nextMessageDisplayT = UnityEngine.Time.realtimeSinceStartup;
        if (messageQueue.Count > 0)
		{
            Message currentMessage = messageQueue.Dequeue();
            textBox.SetText(currentMessage.text);
            nextMessageDisplayT = UnityEngine.Time.realtimeSinceStartup + currentMessage.displayDuration;
            textBox.Show();
            hintText.enabled = true;
		}
	}

    void Update()
    {
        if (UnityEngine.Time.realtimeSinceStartup > nextMessageDisplayT || Input.GetKeyDown(KeyCode.Space))
		{
            ShowNextMessage();
		}
    }
}
