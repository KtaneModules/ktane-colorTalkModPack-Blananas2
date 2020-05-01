using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class QuoteCrazyTalkEndQuote : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable button;
    public TextMesh jdakgflanfadkgnalk;
    public TextMesh FUCK;
    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    int dumbshit = 0;
    int retard1 = 0;
    int retard21 = 0;
    int retard3 = 0;
    int retard4 = 0;
    int uhhhh = 0;
    int uh = 0;
    int dipass = 0;
    int retard5 = 0;

    void Awake () {
        moduleId = moduleIdCounter++;
        button.OnInteract += delegate () { PressButton(); return false; };
    }

    void Start () {
      dumbshit = UnityEngine.Random.Range(1000,10000);
      retard1 = (UnityEngine.Random.Range(0,4)*10) + ((dumbshit % 10000 - dumbshit % 1000) / 1000);
      retard21 = (UnityEngine.Random.Range(0,4)*10) + ((dumbshit % 1000 - dumbshit % 100) / 100);
      retard3 = (UnityEngine.Random.Range(0,4)*10) + ((dumbshit % 100 - dumbshit % 10) / 10);
      retard4 = (UnityEngine.Random.Range(0,4)*10) + (dumbshit % 10);
      Debug.LogFormat("[Quote Crazy Talk End Quote #{0}] The first phrase is {1}. Which has an index of {2}.", moduleId,QuoteCrazyTalkPhrases.phrases[retard1],retard1);
      Debug.LogFormat("[Quote Crazy Talk End Quote #{0}] The second phrase is {1}. Which has an index of {2}.", moduleId,QuoteCrazyTalkPhrases.phrases[retard21],retard21);
      Debug.LogFormat("[Quote Crazy Talk End Quote #{0}] The third phrase is {1}. Which has an index of {2}.", moduleId,QuoteCrazyTalkPhrases.phrases[retard3],retard3);
      Debug.LogFormat("[Quote Crazy Talk End Quote #{0}] The fourth phrase is {1}. Which has an index of {2}.", moduleId,QuoteCrazyTalkPhrases.phrases[retard4],retard4);
      Debug.LogFormat("[Quote Crazy Talk End Quote #{0}] The goal number is {1}.", moduleId,dumbshit);
      StartCoroutine(uhhh());
      StartCoroutine(SHITPISSCOCKSUCKERMOTHERFUCKERCUNTFUCKTITS());
	}

	void PressButton () {
    button.AddInteractionPunch();
    GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
    Audio.PlaySoundAtTransform("BeepBitch", transform);
    dipass += 1;
    uhhhh = uhhhh * 10 + uh;
    Debug.LogFormat("[Quote Crazy Talk End Quote #{0}] The number so far is {1}.", moduleId,uhhhh);
    if (dipass == 4) {
      if (uhhhh == dumbshit) {
        Debug.LogFormat("[Quote Crazy Talk End Quote #{0}] The number you have submitted is {1}. Module disarmed.", moduleId,uhhhh);
        Audio.PlaySoundAtTransform("BeepBoop", transform);
        GetComponent<KMBombModule>().HandlePass();
        StopAllCoroutines();
        jdakgflanfadkgnalk.text = "Quote Crazy\nTalk End Quote";
        FUCK.text = "!";
      }
      else {
        GetComponent<KMBombModule>().HandleStrike();
        Debug.LogFormat("[Quote Crazy Talk End Quote #{0}] The number you have submitted is {1}. Strike, dipass.", moduleId,uhhhh);
        uhhhh = 0;
        dipass = 0;
      }
    }
	}
  IEnumerator uhhh(){
    jdakgflanfadkgnalk.text = QuoteCrazyTalkPhrases.phrases[retard1];
    yield return new WaitForSeconds(0.5f);
    jdakgflanfadkgnalk.text = " ";
    yield return new WaitForSeconds(0.5f);
    jdakgflanfadkgnalk.text = QuoteCrazyTalkPhrases.phrases[retard21];
    yield return new WaitForSeconds(0.5f);
    jdakgflanfadkgnalk.text = " ";
    yield return new WaitForSeconds(0.5f);
    jdakgflanfadkgnalk.text = QuoteCrazyTalkPhrases.phrases[retard3];
    yield return new WaitForSeconds(0.5f);
    jdakgflanfadkgnalk.text = " ";
    yield return new WaitForSeconds(0.5f);
    jdakgflanfadkgnalk.text = QuoteCrazyTalkPhrases.phrases[retard4];
    yield return new WaitForSeconds(0.5f);
    jdakgflanfadkgnalk.text = " ";
    yield return new WaitForSeconds(1f);
    StartCoroutine(uhhh());
  }
  IEnumerator SHITPISSCOCKSUCKERMOTHERFUCKERCUNTFUCKTITS(){
    FUCK.text = "0";
    uh = 0;
    yield return new WaitForSeconds(0.25f);
    FUCK.text = " ";
    yield return new WaitForSeconds(0.25f);
    FUCK.text = "1";
    uh = 1;
    yield return new WaitForSeconds(0.25f);
    FUCK.text = " ";
    yield return new WaitForSeconds(0.25f);
    FUCK.text = "2";
    uh = 2;
    yield return new WaitForSeconds(0.25f);
    FUCK.text = " ";
    yield return new WaitForSeconds(0.25f);
    FUCK.text = "3";
    uh = 3;
    yield return new WaitForSeconds(0.25f);
    FUCK.text = " ";
    yield return new WaitForSeconds(0.25f);
    FUCK.text = "4";
    uh = 4;
    yield return new WaitForSeconds(0.25f);
    FUCK.text = " ";
    yield return new WaitForSeconds(0.25f);
    FUCK.text = "5";
    uh = 5;
    yield return new WaitForSeconds(0.25f);
    FUCK.text = " ";
    yield return new WaitForSeconds(0.25f);
    FUCK.text = "6";
    uh = 6;
    yield return new WaitForSeconds(0.25f);
    FUCK.text = " ";
    yield return new WaitForSeconds(0.25f);
    FUCK.text = "7";
    uh = 7;
    yield return new WaitForSeconds(0.25f);
    FUCK.text = " ";
    yield return new WaitForSeconds(0.25f);
    FUCK.text = "8";
    uh = 8;
    yield return new WaitForSeconds(0.25f);
    FUCK.text = " ";
    yield return new WaitForSeconds(0.25f);
    FUCK.text = "9";
    uh = 9;
    yield return new WaitForSeconds(0.25f);
    FUCK.text = " ";
    yield return new WaitForSeconds(0.25f);
    StartCoroutine(SHITPISSCOCKSUCKERMOTHERFUCKERCUNTFUCKTITS());
  }
}
