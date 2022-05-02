using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TMPLocalization : MonoBehaviour
{
    public LocalizedString localString;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = localString.GetLocalizedString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
