using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alphebetizer_Core
{
    public class Alphebetizer
    {
        private List<string> entries { get; set; }
        private List<string> alphabetized_entries { get; set; }


        public Alphebetizer()
        {
            this.entries = new List<string>();
            this.alphabetized_entries = new List<string>();
        }

        public List<string> alphebetize(List<string> entries)
        {
            this.entries = new List<string>();
            this.entries = entries;
            this.alphabetized_entries = new List<string>();
            string y = entries.Min();            
            while(entries.Count >0 )
            {
                y = entries.Min();
                while(entries.Contains(y))
                {
                    entries.Remove(y);
                }
                alphabetized_entries.Add(y);
                y = entries.Min();
            }
            return this.alphabetized_entries;
        }

    }
}
