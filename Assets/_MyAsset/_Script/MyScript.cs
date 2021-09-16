using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoonSharp.Interpreter;
using System.IO;


public class MyScript : MonoBehaviour
{
    public bool Input1 = false;
    public bool Input2 = false;
    public bool Output1 = false;
    public bool Output2 = false;

    public string myScript;
    Script script;
    // Start is called before the first frame update
    public void initScript(string ScriptText)
    {
        script = new Script();
        myScript = ScriptText;
        script.DoString(myScript);
    }

    // Update is called once per frame
    public void RunScript()
    {
        script.Globals["Input1"] = Input1;
        script.Globals["Input2"] = Input2;
        script.Globals["Output1"] = Output1;
        script.Globals["Output2"] = Output2;

        DynValue val = script.Call(script.Globals["Update"]);

        Output1 = script.Globals.Get("Output1").CastToBool();
        Output2 = script.Globals.Get("Output2").CastToBool();

    }

    public void initScriptFromFile(string FileName)
    {
        script = new Script();
        StreamReader sr = new StreamReader(FileName);
        string tmpString = sr.ReadToEnd();
        sr.Close();
        script.DoString(tmpString);
    }
}
