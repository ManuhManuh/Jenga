using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class APILoader
{

    public static string ReadFile(string url, string typeName)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string content = reader.ReadToEnd();

        return fixJSONArrayContent(content, typeName);
    }

    public static string fixJSONArrayContent(string originalContent, string typeName)
    {
        return "{ \"" + typeName + "\": " + originalContent + " }";
    }


}
