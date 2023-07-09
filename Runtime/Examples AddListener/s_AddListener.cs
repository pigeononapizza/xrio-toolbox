using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_AddListener : MonoBehaviour
{

    void Start()
    {
        GameObject go = new GameObject();

        InputField input = (InputField)go.AddComponent(typeof(InputField));
        input.onValueChanged.AddListener((val) => OnInputChanged(val));

        Toggle tog = go.AddComponent(typeof(Toggle)) as Toggle;
        tog.onValueChanged.AddListener((val) =>
        {
            OnToggleChange(val);
            AlsoDoThis();
        });

        Button btn = go.AddComponent<Button>();
        btn.onClick.AddListener(() => OnButtonPressed());

    }



    void OnToggleChange(bool val)
    {
        print($"Toggle changed to {val}");
    }
    void AlsoDoThis()
    {
        print("Second Method");
    }

    void OnInputChanged(string val)
    {
        print($"Input changed to {val}");
    }

    void OnButtonPressed()
    {
        print("Button was pressed");
    }
}
