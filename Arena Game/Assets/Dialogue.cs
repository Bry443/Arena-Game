// Some Credit goes to BMo on YouTube: https://www.youtube.com/watch?v=8oTYabhj248

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public static Dialogue instance;

    private int index;
    private bool talk;

    // Start is called before the first frame update
    void Start()
    {
        // Start with empty string
        textComponent.text = string.Empty;
        talk = false;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {

        if (SayMessage.instance.GetStatus() && Input.GetKeyDown(KeyCode.E))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
                //talk = false;
                SayMessage.instance.ResetTalk(talk);
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
            
        }
    }

    void StartDialogue()
    {
        index = 0;
    }
    
    IEnumerator TypeLine()
    {
        // type each character 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
