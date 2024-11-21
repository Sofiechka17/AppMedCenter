using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slovar
{
    public class Tutor
    {
        private Dictionary<string, string> _dic = new Dictionary<string, string>();
        private Random _rand = new Random();
        public void AddWord(string end, string rus)
        {
            _dic.Add(end, rus);
        }

        public bool CheckWord(string end, string rus)
        {
            var answer = _dic[end];
            return answer.ToLower() == rus.ToLower();
        }

        public string Translate(string end)
        {
            if (_dic.ContainsKey(end))
                return _dic[end];
            else
                return null;
        }

        public string GetRandomEngWord()
        {
            var r = _rand.Next(0, _dic.Count);
            var keys = new List<string>(_dic.Keys);
            return keys[r];
        }
    }
}
