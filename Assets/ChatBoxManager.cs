using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChatBoxManager : MonoBehaviour
{
    public static ChatBoxManager instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    [SerializeField] Transform ChatBox;
    [SerializeField] Text chatText;
    [SerializeField] Queue<GameObject> queue_Text_Contents;


    // Use this for initialization
    void Start()
    {
        queue_Text_Contents = new Queue<GameObject>();
        // array_Text_Contents = new Text[100];

    }
    public void EnqueueText(string _content)
    {
        GameObject temp = Instantiate(chatText.gameObject, Vector3.zero, Quaternion.identity);
        temp.transform.parent = ChatBox.transform;
        // _content = "eqewrdasfkjdasfhasfkjjhfkjashfadkjfdhasfkjadshfdkjashfhdasfdashfasjhfadksflhadsfkjads";
        temp.GetComponent<Text>().text = _content;
        RectTransform rt = temp.GetComponent(typeof(RectTransform)) as RectTransform;
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, temp.GetComponent<Text>().preferredHeight);
        queue_Text_Contents.Enqueue(temp);

        if (queue_Text_Contents.Count > 100)
        {
            GameObject finalElementQueue = queue_Text_Contents.Dequeue();
            Destroy(finalElementQueue);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

        }
    }
}


