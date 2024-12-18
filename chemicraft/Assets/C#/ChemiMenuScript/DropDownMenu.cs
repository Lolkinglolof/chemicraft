using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text numberText;

    public void Dropdown(int index)
    {
        switch(index)
        {
            case 0: numberText.text = "0"; break;
            case 1: numberText.text = "1"; break;
            case 2: numberText.text = "2"; break;
        }
    }
}
