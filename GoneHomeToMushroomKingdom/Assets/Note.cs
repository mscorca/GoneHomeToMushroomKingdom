using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour {

    //The Text Of The Note
    private Text text;

    // Use this for initialization
    void Awake () {
        text = GetComponent<Text>();
        Debug.Log(text.font);
    }

    public Text GetText ()
    {
        return text;
    }

    public Font GetFont()
    {
        return text.font;
    }
}
