﻿using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace ConsoleNaverMovieFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string clientID = "ides3K7kXxmna11Vi4wX";
            string clientSecret = "JAd4Qrrcqp";
            string search = "starwars"; // 변경 가능
            string openApiUrl = $"https://openapi.naver.com/v1/search/movie?query={search}";

            string responseJson = GetOpenApiResult(openApiUrl, clientID, clientSecret);
            JObject parsedJson = JObject.Parse(responseJson);

            int total = Convert.ToInt32(parsedJson["total"]);
            Console.WriteLine($"총 검색결과 : {total}");
            int display = Convert.ToInt32(parsedJson["display"]);
            Console.WriteLine($"화면출력 : {display}");

            JToken items = parsedJson["items"];
            JArray json_array = (JArray)items;

            foreach (var item in json_array)
            {
                Console.WriteLine($"{item["title"]} / {item["image"]} / {item["subtitle"]} / {item["actor"]} ");
            }
        }

        private static string GetOpenApiResult(string openApiUrl, string clientID, string clientSecret)
        {
            string result = "";

            try
            {
                WebRequest request = WebRequest.Create(openApiUrl);
                request.Headers.Add("X-Naver-Client-Id", clientID);
                request.Headers.Add("X-Naver-Client-Secret", clientSecret);

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                result = reader.ReadToEnd();

                reader.Close();
                stream.Close();
                response.Close();                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"예외발생 : {ex}");
            }

            return result;
        }
    }
}
