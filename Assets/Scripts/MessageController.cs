using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    public string messageText;
    public GameObject messageTextPanel, gameController;
    public GameObject bed;
    public bool rightObject;
    public string bedName;
    public GameObject textBox, textBackground;
    private bool aux, collected;
    void Start()
    {
        if(bedName!=null){
            bed = GameObject.Find(bedName);
        }
        aux = false;
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetKnifTextSize() {
        if (this.gameObject.name == "Knife")
        {
            textBackground.GetComponent<RectTransform>().sizeDelta = 
                new Vector2(textBackground.GetComponent<RectTransform>().sizeDelta.x,308.57f);
            textBox.GetComponent<RectTransform>().sizeDelta =
                new Vector2(textBox.GetComponent<RectTransform>().sizeDelta.x, 313.7f);
        }
        else
        {
            textBackground.GetComponent<RectTransform>().sizeDelta =
                new Vector2(textBackground.GetComponent<RectTransform>().sizeDelta.x, 247.8f);
            textBox.GetComponent<RectTransform>().sizeDelta =
                new Vector2(textBox.GetComponent<RectTransform>().sizeDelta.x, 247.8f);
        }
    }
    private IEnumerator WaitToDisablePanel()
    {
        SetKnifTextSize();
        if(this.gameObject.tag != "bed" && rightObject)
        {
            messageTextPanel.SetActive(true);
            if (rightObject && !collected)
            {
                collected = true;
                gameController.GetComponent<GameController>().AddCollected();
            }
        }
        messageTextPanel.GetComponentInChildren<Text>().text = messageText;
        yield return new WaitForSeconds(7f);
        messageTextPanel.SetActive(false);
        Destroy(this.gameObject);

        if (this.gameObject.tag != "bed" && !rightObject && this.gameObject.tag != "frame") {
            messageTextPanel.SetActive(true);
            messageTextPanel.GetComponentInChildren<Text>().text = messageText;
            yield return new WaitForSeconds(7f);
            messageTextPanel.SetActive(false);
        }
        else if(this.gameObject.tag == "bed")
        {
            bed.transform.position = new Vector3(bed.transform.position.x, 1.55f, bed.transform.position.z);
            yield return new WaitForSeconds(2f);
            messageTextPanel.SetActive(true);
            messageTextPanel.GetComponentInChildren<Text>().text = messageText;
            yield return new WaitForSeconds(4f);

            if (rightObject && !collected)
            {
                collected = true;
                gameController.GetComponent<GameController>().AddCollected();
            }
            messageTextPanel.SetActive(false);
        }
        else if (this.gameObject.tag == "picture frame" && gameController.GetComponent<GameController>().collected
            >= gameController.GetComponent<GameController>().collectedTarget)
        {
            gameController.GetComponent<GameController>().IsGameOver();
        }
        else if (this.gameObject.tag == "picture frame (1)")
        {
            messageTextPanel.SetActive(true);
            messageTextPanel.GetComponentInChildren<Text>().text = messageText;
            yield return new WaitForSeconds(5f);
            messageTextPanel.SetActive(false);
        }
    }

    public void SetMessage()
    {
        StartCoroutine(WaitToDisablePanel());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            aux = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && aux)
        {
            SetMessage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            aux = false;
        }
    }
}
