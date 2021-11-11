using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.JsonStringHelper
{
    public static class myDeserialiseFromJson<T>
    {
        public static T Deserialise(string jsonString)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonString);
            MemoryStream stream1 = new MemoryStream(byteArray);
            stream1.Position = 0;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            T newData = (T)ser.ReadObject(stream1);

            return newData;
        }

        public static T DeserialiseApiResponse(string jsonString)
        {

            int cutoffPos = jsonString.IndexOf(':');
            jsonString = jsonString.Remove(0, cutoffPos + 1);
            jsonString = jsonString.Remove(jsonString.Length - 1);

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonString);

            MemoryStream stream1 = new MemoryStream(byteArray);
            stream1.Position = 0;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            T newData = (T)ser.ReadObject(stream1);

            return newData;
        }
    }

    public static class SerialiseToJson<T>
    {
        public static string Serialise(T data)
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(stream1, data);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);

            return sr.ReadToEnd();
        }
    }

    public class JsonParamBuilder
    {
        private string _paramList;
        public JsonParamBuilder()
        {
            _paramList = "{";
        }
        public string GetJSonParam()
        {
            string returnParamList = _paramList.Remove(_paramList.Length - 1);
            return returnParamList + "}";
        }
        public void AddParam<T>(string paramName, T paramData)
        {
            string str = SerialiseToJson<T>.Serialise(paramData);
            _paramList = _paramList + "\"" + paramName + "\":" + str + ",";
        }
    }
}
