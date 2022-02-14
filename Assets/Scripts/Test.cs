using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        TextData.SetEvent("test");
        TextData.UpdateDialog();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void test1()
    {

    }
    public void test2()
    {
    }
}
