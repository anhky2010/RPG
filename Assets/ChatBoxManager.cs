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
    [SerializeField] string[] text_Content_Array;
    int curent_Array_Index = 0;

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
        _content = "eqewrdasfkjdasfhasfkjjhfkjashfadkjfdhasfkjadshfdkjashfhdasfdashfasjhfadksflhadsfkjads";
        temp.GetComponent<Text>().text = _content;
        int lines = (_content.Length / 18) + 1;//lay phan nguyen +1
        RectTransform rt = temp.GetComponent(typeof(RectTransform)) as RectTransform;
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y * lines);
        queue_Text_Contents.Enqueue(temp);

        if (queue_Text_Contents.Count > 100)
        {
            queue_Text_Contents.Dequeue();
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

        }
    }
}


