using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Common.Common
{

    public class userModel
    {

    }

    public class ClassPropertyHelper
    {
        public object setProperty(object usr, string propName, string propValue)
        {
            PropertyInfo propertyInfo = usr.GetType().GetProperty(propName);

            if (propertyInfo != null)
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                }
                else if (propertyInfo.PropertyType == typeof(Int32)|| propertyInfo.PropertyType == typeof(Int64))
                {
                }
                propertyInfo.SetValue(usr, Convert.ChangeType(propValue, propertyInfo.PropertyType), null);
                string _propValue = usr.GetType().GetProperty(propName).GetValue(usr).ToString();
            }
            return usr;
        }
        public object setProperty(userModel usr, string propName, string propValue)
        {
            PropertyInfo propertyInfo = usr.GetType().GetProperty(propName);

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(usr, Convert.ChangeType(propValue, propertyInfo.PropertyType), null);
                string _propValue = usr.GetType().GetProperty(propName).GetValue(usr).ToString();
            }
            return usr;
        }





        public static void SetKey<T>(T obj, Dictionary<string,string> _tempData)
        {
            System.Type type = typeof(T);

            // Get our Foreign Key that we want to maintain
            String foreignKey = _tempData["ForeignKey"].ToString();

            // If we do not have a Foreign Key, we do not need to set a property
            if (String.IsNullOrEmpty(foreignKey))
                return;

            // Get our the value that we need to set our Foreign Key to
            String value = _tempData[foreignKey].ToString();

            // Get our property via reflection so that we can invoke methods against property
            System.Reflection.PropertyInfo prop = type.GetProperty(foreignKey.ToString());

            // Gets what the data type is of our property (Foreign Key Property)
            System.Type propertyType = prop.PropertyType;

            // Get the type code so we can switch
            System.TypeCode typeCode = System.Type.GetTypeCode(propertyType);
            try
            {

                switch (typeCode)
                {
                    case TypeCode.Int32:
                        prop.SetValue(type, Convert.ToInt32(value), null);
                        break;
                    case TypeCode.Int64:
                        prop.SetValue(type, Convert.ToInt64(value), null);
                        break;
                    case TypeCode.String:
                        prop.SetValue(type, value, null);
                        break;
                    case TypeCode.Object:
                        if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                        {
                            prop.SetValue(obj, Guid.Parse(value), null);
                            return;
                        }
                        break;
                    default:
                        prop.SetValue(type, value, null);
                        break;
                }

                return;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to set property value for our Foreign Key");
            }



        }



        public void FromController(Type ctrl)
        {
            string ProductCode = (string)ctrl.GetProperty("ProductCode", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).GetValue(null, null);
            string ProductName = (string)ctrl.GetProperty("ProductName", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).GetValue(null, null);
            string ProductKey = (string)ctrl.GetProperty("ProductKey", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).GetValue(null, null);
            string Version = (string)ctrl.GetProperty("Version", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).GetValue(null, null);
        }

    }
}
