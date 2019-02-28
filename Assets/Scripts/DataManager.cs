using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string countryDatabase = "CountryDatabase";
    Dictionary<string, JsonData> DictionaryCountryDatabase;


    

    public void Init()
    {
        if (instance == null)
            instance = this;
        
        DictionaryCountryDatabase = LoadDatabaseBySlugName("CountryDatabase");
       

    }    

    public Dictionary<string,string> GetCountryInfo(string slugName)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();
        
        if (DictionaryCountryDatabase.ContainsKey(slugName))
        {
            string jsonData = DictionaryCountryDatabase[slugName].ToJson();            

            result = JsonMapper.ToObject<Dictionary<string, string>>(jsonData);
        }
       
        return result;
    }

    public static Dictionary<string, JsonData> LoadDatabaseBySlugName(string name)
    {
        Dictionary<string, JsonData> result = new Dictionary<string, JsonData>();
        TextAsset Text = UnityEngine.Resources.Load(name) as TextAsset;
        if (Text == null)
        {
            Debug.LogError(name + " Not Found");
        }

        var JsonText = JsonMapper.ToObject(Text.text);       

        if (JsonText.GetJsonType() != JsonType.Array)
        {
            Debug.LogError(name + " JsonType not Array");
            return null;
        }

        if (JsonText.Count == 0)
        {
            Debug.LogError(name + " JsonText.Count == 0");
            return null;
        }

        for (int i = 0; i < JsonText.Count; i++)
        {            
            result.Add(JsonText[i]["SlugName"].ToString(), JsonText[i]);
        }
       
        return result;
    }

   /* public static Dictionary<int, JsonData> LoadDatabaseByID(string name)
    {
        Dictionary<int, JsonData> result = new Dictionary<int, JsonData>();
        TextAsset Text = UnityEngine.Resources.Load(name) as TextAsset;
        if (Text == null)
        {
            Debug.LogError(name + " Not Found");
        }
        var JsonText = JsonMapper.ToObject(Text.text);



        if (JsonText.GetJsonType() != JsonType.Array)
        {
            return null;
        }

        if (JsonText.Count == 0)
        {
            return null;
        }

        for (int i = 0; i < JsonText.Count; i++)
        {
            result.Add((int)JsonText[i]["ID"], JsonText[i]);
        }

        return result;
    }*/
}
