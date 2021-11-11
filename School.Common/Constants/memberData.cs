using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.Constants
{
    public class memberData
    {
        public string _Type { get; set; }
        public string getType(string _type)
        {
            Dictionary<string, string> _data = data();
            for (int index = 0; index < _data.Count; index++)
            {
                var item = _data.ElementAt(index);
                if (item.Key ==_type)
                {
                    return item.Value;
                }
            }

            return "";
        }

        public Dictionary<string, string> data()
        {
            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();
            dataDictionary.Add("type0", "type 0");
            dataDictionary.Add("type1", "type 1");
            dataDictionary.Add("type2", "type 2");
            dataDictionary.Add("type3", "type 3");
            return dataDictionary;
        }


        public string _getType(string _type)
        {
            foreach (KeyValuePair<string, string> _KeyValuePair in data())
            {
                if (_KeyValuePair.Key ==_type)
                {
                    return _KeyValuePair.Value;
                }
            }
            return "";
        }
    }
}
