using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionaries
{
    class Dictionaries
    {
        private static Dictionaries instance = null;

        public static Dictionaries Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Dictionaries();
                    return instance;
                }
                else
                    return instance;
            }
        }

        public string Name { get; set; }
        public string FilePath { get=>@"file.txt"; }
        public Dictionary<string, string> Luget = new Dictionary<string, string>(); 
        private Dictionaries(){}

    }
}
