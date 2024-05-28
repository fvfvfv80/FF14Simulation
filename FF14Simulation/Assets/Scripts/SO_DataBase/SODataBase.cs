using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


//[CreateAssetMenu(fileName = "SODataBase", menuName = "Scriptable Objects/SODataBase_")]
public abstract class SODataBase<T> : ScriptableObject where T : DBData
{
    public bool DoTest;

    public UnityEngine.Object JsonFile;

    protected abstract string JsonPath { get; }

    public List<T> DataList;

    public void Awake()
    {
        Debug.Log(this.name + " wake");
    }

    public void ParseJsonData()
    {
        if(!DoTest)
        {
            Debug.Log(this.name + " parseData");
            string jsonContent;
            //jsonContent = File.ReadAllText(JsonPath);
            jsonContent=JsonFile.ToString();
            Debug.Log(jsonContent);

            DataInit(jsonContent);


        }
    }

    public abstract void DataInit(string jContent);


    

}
