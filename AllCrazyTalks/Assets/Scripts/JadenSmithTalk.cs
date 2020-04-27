using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class JadenSmithTalk : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable[] Buttons;
    public TextMesh markiplierspiss;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    int stiffcocks = 0;
    string temp = "";

    void Awake () {
        moduleId = moduleIdCounter++;
        foreach (KMSelectable Button in Buttons) {
            Button.OnInteract += delegate () { ButtonsPress(Button); return false; };
        }
    }
    void Start () {
      StartCoroutine(TheJade());
	}
	void ButtonsPress (KMSelectable Button) {
    Button.AddInteractionPunch();
    GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Button.transform);
    for (int j = 0; j < 2; j++) {
      if (Button == Buttons[j]) {
        if (j == stiffcocks) {
          GetComponent<KMBombModule>().HandlePass();
          markiplierspiss.text = "Jaden Smith\nTalk";
          Audio.PlaySoundAtTransform("SolveSFX", transform);
        }
        else {
          GetComponent<KMBombModule>().HandleStrike();
          StartCoroutine(TheJade());
        }
      }
    }
	}
  IEnumerator TheJade(){
    stiffcocks = UnityEngine.Random.Range(0,2);
    if (stiffcocks == 0) {
      temp = YesJaden.Phrases[UnityEngine.Random.Range(0,YesJaden.Phrases.Count())];
      string newPhrase = "";
        int letterCount = 0;
        for (int i = 0; i < temp.Length; i++)
        {
            letterCount = letterCount + 1;
            if (temp[i] == ' ' && letterCount >= 20)
            {
                newPhrase += "\n";
                letterCount = 0;
            } else
            {
                newPhrase += temp[i];
            }
        }
        temp = newPhrase;
        markiplierspiss.text = temp;
    }
    else {
      temp = NoJaden.Phrases[UnityEngine.Random.Range(0,NoJaden.Phrases.Count())];
      string newPhrase = "";
        int letterCount = 0;
        for (int i = 0; i < temp.Length; i++)
        {
            letterCount = letterCount + 1;
            if (temp[i] == ' ' && letterCount >= 20)
            {
                newPhrase += "\n";
                letterCount = 0;
            } else
            {
                newPhrase += temp[i];
            }
        }
        temp = newPhrase;
        markiplierspiss.text = temp;
    }
    yield return null;
  }
}
