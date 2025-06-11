using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2_Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ILRuntimeMgr.Instance.StartILRuntime(() =>
        {
            print("ILRuntime启动成功、初始化成功，可以在这处理逻辑");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
