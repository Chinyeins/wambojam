using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    public Dictionary<Language,Translations> translation=new Dictionary<Language, Translations>();
    public Language language;

    public enum Language
    {
        GERMAN,
        ENGLISH
    } 
    public string translate(string text)
    {
        if (translation[language].translation.ContainsKey(text))
            return translation[language].translation[text];
        else
            return text;
    }
    // Start is called before the first frame update
    void Start()
    {
        Translations translationE = new Translations();
        translationE.translation.Add("„Ich erinnere mich wieder. Meine Schwester ist schwer krank und wurde aus diesem Grund in ihrem Zimmer eingesperrt. Ich muss sie irgendwie da rausholen, aber zuerst muss ich zu ihr gelangen.„", "„I do remember.My sister has been locked in her room due to her illnes.I have to get her out of there somehow.„");
        translationE.translation.Add("„Ich erinnere mich an diese Schuhe und das Kleid. Sie gehören zu Mutter. Sie hat immer in ihrem Schaukelstuhl gesessen und aus dem Fenster  geschaut.“", "“I do remmeber the shoes and the dress.They belonged to my mother.She was allway sitting on her rocking chair, looking out of the window.“");
        translationE.translation.Add("„Ich erinnere mich an diese Schuhe und das Kleid.Sie gehören zu Mutter. Sie hat immer in ihrem Schaukelstuhl gesessen und aus dem Fenster geschaut“", "");
        translationE.translation.Add("„Ich kann mich an mein Holzschwert erinnern. Ich habe früher immer gerne  damit gespielt.“", "“I do remmeber the wooden sword. I did allways like playing with it.“");
        translationE.translation.Add("„Mutter? Ich erinnere mich...„", "Mother? I remeber...");

        Translations translationD = new Translations();
        translationD.translation.Add("„Ich erinnere mich wieder. Meine Schwester ist schwer krank und wurde aus diesem Grund in ihrem Zimmer eingesperrt. Ich muss sie irgendwie da rausholen, aber zuerst muss ich zu ihr gelangen.„", "„Ich erinnere mich wieder. Meine Schwester ist schwer krank und wurde aus diesem Grund in ihrem Zimmer eingesperrt. Ich muss sie irgendwie da rausholen, aber zuerst muss ich zu ihr gelangen.„");
        translationD.translation.Add("„Ich erinnere mich an diese Schuhe und das Kleid. Sie gehören zu Mutter. Sie hat immer in ihrem Schaukelstuhl gesessen und aus dem Fenster  geschaut.“", "„Ich erinnere mich an diese Schuhe und das Kleid. Sie gehören zu Mutter. Sie hat immer in ihrem Schaukelstuhl gesessen und aus dem Fenster  geschaut.“");        
        translationD.translation.Add("„Ich kann mich an mein Holzschwert erinnern. Ich habe früher immer gerne  damit gespielt.“", "„Ich kann mich an mein Holzschwert erinnern. Ich habe früher immer gerne  damit gespielt.“");
        translationD.translation.Add("„Mutter? Ich erinnere mich...„", "„Mutter? Ich erinnere mich...„");

        translation.Add(Language.ENGLISH, translationD);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
