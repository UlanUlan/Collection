using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public class Sotrudnik
    {
        Random rand = new Random();
        public Sotrudnik(string _fullName, bool _pol, int _age, int _salarySize)
        {
            fullName = _fullName;
            //fullName = "XJ"+rand.Next().ToString();
            //pol = age < 63 ? pol = false : pol = true;
            pol = _pol;
            age = _age;
            salarySize = _salarySize;
        }
        public string fullName { get; set; }
        public bool pol { get; set; }
        public int age { get; set; }
        public int salarySize { get; set; }
    }
}
