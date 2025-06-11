using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

public class Lesson8_CallCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().Require("Main");

        LuaFunction function = LuaMgr.GetInstance().LuaState.GetFunction("StartDelay");
        function.Call();
        function.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
