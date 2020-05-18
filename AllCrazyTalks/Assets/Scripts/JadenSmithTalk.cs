using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        Debug.LogFormat("[Mental Math #{0}] The phrase says {1}.", moduleId, temp);
        if (stiffcocks == 0) {
          Debug.LogFormat("[Mental Math #{0}] This was said by the Jade.", moduleId, temp);
        }
        else {
          Debug.LogFormat("[Mental Math #{0}] This was not said by the Jade.", moduleId, temp);
        }
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
  //Twitch Plays
  #pragma warning disable 414
  private readonly string TwitchHelpMessage = @"Use !{0} y/VoteYea/yes/yay/n/VoteNay/no/nay/left/right to press yes or no button.";
  #pragma warning restore 414
  IEnumerator ProcessTwitchCommand(string flaccidcock){
	flaccidcock = flaccidcock.Trim();
    if (Regex.IsMatch(flaccidcock, @"^(?:y(?:es|ay)?|VoteYea|left?)$", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)){
      yield return null;
      Buttons[0].OnInteract();
      yield return new WaitForSeconds(.1f);
    }
    else if (Regex.IsMatch(flaccidcock, @"^(?:n(?:o|ay)?|VoteNay|right?)$", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)){
      yield return null;
      Buttons[1].OnInteract();
      yield return new WaitForSeconds(.1f);
    }
    else
      yield return "sendtochaterror Valid commands can be found by using !{1} help.";
    yield break;
  }
  IEnumerator TwitchHandleForcedSolve(){
    Buttons[stiffcocks].OnInteract();
    yield return new WaitForSeconds(.1f);
  }
}
