using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alphebetizer_Core
{
    // I'm going to add a case insensiteve lookup to the lists.
    // min should pick the minimum value based on the leftmost character,
    // but I'm sure I could find some edge case that breaks it.
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
            // I'll need to handle formatting on the other side- which will likely involve stripping and replacing all whitespace characters...
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
