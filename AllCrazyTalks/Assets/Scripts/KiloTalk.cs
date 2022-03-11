using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class KiloTalk : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;

    public KMSelectable[] Screens;
    public KMSelectable Submit;
    public TextMesh Statement;
    public TextMesh[] Nums;

    ulong number = 0;
    int initial = 0;
    int unitA = 0; //Gram, Kilogram, Tonne/Metric Ton, Slug, Pound, Ounce, Ton
    int unitB = 0;
    int hundreds = 0;
    int tens = 0;
    int ones = 0;
    ulong[] conv = {
      1, 1000000, 1000, 68520, 2205000, 35270000, 1102,
      1000000000000, 1, 1000000, 68520000, 2205000000, 35270000000, 1102000,
      1000000000000000, 1000000000000, 1, 68520000000, 2205000000000, 35274000000000, 1102000000,
      14594000000000, 14594000000, 14590000, 1, 32170000000, 514800000000, 16090000, 
      453600000000, 453600000, 453600, 31080000, 1, 16000000000, 500000,
      28349500000, 28349500, 28350, 1943000, 62500000, 1, 31250,
      907185000000000, 907185000000, 907200000, 62160000000, 2000000000000, 32000000000000, 1
    };
    string[] names = {"Grams", "Kilograms", "Tonnes", "Slugs", "Pounds", "Ounces", "Tons"};

    //Logging
    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable Screen in Screens) {
            Screen.OnInteract += delegate () { ScreenPress(Screen); return false; };
        }

        Submit.OnInteract += delegate () { SubmitPress(); return false; };

    }

    // Use this for initialization
    void Start () {
      number = (ulong)(UnityEngine.Random.Range(0,900) + 100);
      initial = (int)number;
      unitA = UnityEngine.Random.Range(0,7);
      unitB = UnityEngine.Random.Range(0,7);
      while (unitA == unitB) {
        unitB = UnityEngine.Random.Range(0,7);
      }
      if ((unitA == 2 || unitB == 2) && UnityEngine.Random.Range(0,2) == 0) {
        names[2] = "Metric Tons";
      }
      number *= conv[unitA*7 + unitB];
      Debug.LogFormat("[Kilo Talk #{0}] The starting value is {1} {2}. The target unit is {3}.", moduleId, initial, names[unitA], names[unitB]);
      Debug.LogFormat("[Kilo Talk #{0}] {1} {2} = {3} {4}.", moduleId, initial, names[unitA], ((float)(number/1000000000)).ToString(), names[unitB]);
      number /= 1000000000;
      number %= 1000;
      Debug.LogFormat("[Kilo Talk #{0}] Final answer is {1}.", moduleId, number);
      Statement.text = String.Format("{0} {1}\nto {2}", initial, names[unitA], names[unitB]);

    }

    void ScreenPress(KMSelectable Screen) {
      Screen.AddInteractionPunch();
      if (moduleSolved) {return;}
        for (int s = 0; s < 3; s++) {
          if (Screens[s] == Screen) {
            switch (s) {
              case 0: hundreds = (hundreds + 1)%10; Nums[0].text = hundreds.ToString(); break;
              case 1: tens = (tens + 1)%10; Nums[1].text = tens.ToString(); break;
              case 2: ones = (ones + 1)%10; Nums[2].text = ones.ToString(); break;
            }
          }
        }
    }

    void SubmitPress() {
      Submit.AddInteractionPunch();
      if (moduleSolved) {return;}
      if (hundreds * 100 + tens * 10 + ones == (int)number) {
        Debug.LogFormat("[Kilo Talk #{0}] Submitted {1}, which is correct. Module solved.", moduleId, number);
        Audio.PlaySoundAtTransform("Kachow", transform);
        Statement.text = "Kilo Talk";
        Nums[0].text = "4"; Nums[1].text = "2"; Nums[2].text = "0"; 
        GetComponent<KMBombModule>().HandlePass();
        moduleSolved = true;
      } else {
        Debug.LogFormat("[Kilo Talk #{0}] Submitted {1}, which is incorrect. Strike!", moduleId, hundreds * 100 + tens * 10 + ones);
        GetComponent<KMBombModule>().HandleStrike();
      }
    }

}
