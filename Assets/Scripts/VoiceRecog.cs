using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoiceRecog : MonoBehaviour
{
    [SerializeField] private string[] keywords;

    private KeywordRecognizer Recognizer;
    
    void Start()
    {
        keywords = new string[0];
        keywords[0] = "Reset";
        Recognizer = new KeywordRecognizer(keywords);
        Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (args.text == keywords[0])
        {
            SceneManager.LoadScene("TempoVR");
        }
    }
    
    void Update()
    {
        
    }
}
