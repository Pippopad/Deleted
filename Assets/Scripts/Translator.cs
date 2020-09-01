using UnityEngine;
using UnityEngine.UI;

public class Translator : MonoBehaviour
{
    public string TextId;

    void Start()
    {
        if (TextId == "ISOCode")
            Debug.Log(TranslatorSystem.GetLanguage());
        else
            Debug.Log(TranslatorSystem.Fields[TextId]);
    }
}
