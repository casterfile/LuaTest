using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MainGame : MonoBehaviour
{
    MyScript testScript;
    public TMP_InputField tmpInput;
    public Toggle togInput1;
    public Toggle togInput2;
    public Toggle togOutput1;
    public Toggle togOutput2;


    // Start is called before the first frame update
    void Start()
    {
        string tmpString = @"
        function Update()
            if Input1 then
                Output1 = true
            else
                Output1 = false
            end
        end
        ";

        testScript = tmpInput.GetComponentInChildren<MyScript>();
        testScript.initScript(tmpString);
        tmpInput.text = testScript.myScript;
    }

    // Update is called once per frame
    public void UpdateScript()
    {
        string tmpString = tmpInput.text;
        testScript.initScript(tmpString);
        testScript.Input1 = togInput1.isOn;
        testScript.Input2 = togInput1.isOn;
        testScript.RunScript();

        togOutput1.isOn = testScript.Output1;
        togOutput2.isOn = testScript.Output2;
    }
}
