using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;


//This took 2 hours to write because COD decided to automatically update and brick my hard drive
//I would change the skybox of the levels depending on weather but it takes Visual Studio 30 seconds to process me type "private string"
//Or it would've played a constant loop of me saying whatever the weather was
public class ForcedWeatherAPI : MonoBehaviour
{
    //Code you provided
    [Serializable]
    public class Response
    {
        [Serializable]
        public class ForcedWeatherAPI
        {
            public string main;
        }

        public ForcedWeatherAPI[] weather;
    }

    //Personal API key
    private string APIKey = "45063ad0ce65f0b6ee055ca004e10c1e";

    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        //sets TextMeshPro to whatever is on the game object
        textMeshPro = GetComponent<TextMeshProUGUI>();
        StartCoroutine(GetWeather());
    }
    IEnumerator GetWeather()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://api.openweathermap.org/data/2.5/weather?q=hooksett,nh,usa&APPID=" + APIKey))
        {

            yield return webRequest.SendWebRequest();
            Response resp = JsonUtility.FromJson<Response>(webRequest.downloadHandler.text);

            //Sets text on current object
            textMeshPro.text = "It is currently " + resp.weather[0].main + " in Hookset, NH";
        }
    }

}
