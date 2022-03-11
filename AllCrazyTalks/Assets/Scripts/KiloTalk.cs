using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class KiloTalk : MonoBehaviour
{

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
    string[] names = { "Grams", "Kilograms", "Tonnes", "Slugs", "Pounds", "Ounces", "Tons" };

    //Logging
    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    void Awake()
    {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable Screen in Screens)
        {
            Screen.OnInteract += delegate () { ScreenPress(Screen); return false; };
        }

        Submit.OnInteract += delegate () { SubmitPress(); return false; };

    }

    // Use this for initialization
    void Start()
    {
        number = (ulong)(UnityEngine.Random.Range(0, 900) + 100);
        initial = (int)number;
        unitA = UnityEngine.Random.Range(0, 7);
        unitB = UnityEngine.Random.Range(0, 7);
        while (unitA == unitB)
        {
            unitB = UnityEngine.Random.Range(0, 7);
        }
        if ((unitA == 2 || unitB == 2) && UnityEngine.Random.Range(0, 2) == 0)
        {
            names[2] = "Metric Tons";
        }
        number *= conv[unitA * 7 + unitB];
        Debug.LogFormat("[Kilo Talk #{0}] The starting value is {1} {2}. The target unit is {3}.", moduleId, initial, names[unitA], names[unitB]);
        Debug.LogFormat("[Kilo Talk #{0}] {1} {2} = {3} {4}.", moduleId, initial, names[unitA], ((float)(number / 1000000000)).ToString(), names[unitB]);
        number /= 1000000000;
        number %= 1000;
        Debug.LogFormat("[Kilo Talk #{0}] Final answer is {1}.", moduleId, number);
        Statement.text = String.Format("{0} {1}\nto {2}", initial, names[unitA], names[unitB]);

    }

    void ScreenPress(KMSelectable Screen)
    {
        Screen.AddInteractionPunch();
        if (moduleSolved) { return; }
        for (int s = 0; s < 3; s++)
        {
            if (Screens[s] == Screen)
            {
                switch (s)
                {
                    case 0: hundreds = (hundreds + 1) % 10; Nums[0].text = hundreds.ToString(); break;
                    case 1: tens = (tens + 1) % 10; Nums[1].text = tens.ToString(); break;
                    case 2: ones = (ones + 1) % 10; Nums[2].text = ones.ToString(); break;
                }
            }
        }
    }

    void SubmitPress()
    {
        Submit.AddInteractionPunch();
        if (moduleSolved) { return; }
        if (hundreds * 100 + tens * 10 + ones == (int)number)
        {
            Debug.LogFormat("[Kilo Talk #{0}] Submitted {1}, which is correct. Module solved.", moduleId, number);
            Audio.PlaySoundAtTransform("Kachow", transform);
            Statement.text = "Kilo Talk";
            Nums[0].text = "4"; Nums[1].text = "2"; Nums[2].text = "0";
            GetComponent<KMBombModule>().HandlePass();
            moduleSolved = true;
        }
        else
        {
            Debug.LogFormat("[Kilo Talk #{0}] Submitted {1}, which is incorrect. Strike!", moduleId, hundreds * 100 + tens * 10 + ones);
            GetComponent<KMBombModule>().HandleStrike();
        }
    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = "!{0} submit 420 [Submits 420 as your answer.] | Submissions must be 1, 2, or 3 digits long.";
#pragma warning restore 414

    private IEnumerator ProcessTwitchCommand(string command)
    {
        var m = Regex.Match(command, @"^\s*submit\s+(\d+)\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        if (!m.Success)
            yield break;
        var p = m.Groups[1].Value;
        if (p.Length > 3)
        {
            yield return "sendtochaterror Too many digits! Please submit a 1, 2, or 3 digit number.";
            yield break;
        }
        if (p.Length < 1)
        {
            yield return "sendtochaterror Not enough digits! Please submit a 1, 2, or 3 digit number.";
            yield break;
        }
        yield return null;
        while (p.Length < 3)
            p = "0" + p;
        while (hundreds != p[0] - '0')
        {
            Screens[0].OnInteract();
            yield return new WaitForSeconds(0.05f);
        }
        while (tens != p[1] - '0')
        {
            Screens[1].OnInteract();
            yield return new WaitForSeconds(0.05f);
        }
        while (ones != p[2] - '0')
        {
            Screens[2].OnInteract();
            yield return new WaitForSeconds(0.05f);
        }
        Submit.OnInteract();
    }

    private IEnumerator TwitchHandleForcedSolve()
    {
        int h = (int)number % 1000 / 100;
        int t = (int)number % 100 / 10;
        int o = (int)number % 10;
        while (hundreds != h)
        {
            Screens[0].OnInteract();
            yield return new WaitForSeconds(0.05f);
        }
        while (tens != t)
        {
            Screens[1].OnInteract();
            yield return new WaitForSeconds(0.05f);
        }
        while (ones != o)
        {
            Screens[2].OnInteract();
            yield return new WaitForSeconds(0.05f);
        }
        Submit.OnInteract();
    }
}
