using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphebetizer.Actions
{
    // mechanism to handle formatting the whitespace (it's been causing issues within the original alphebetizer.
    /// <summary>
    /// grants access to "eliminate_whitespace" and "recreate_whitespace" voids, 
    /// which will provide values accessible through "with_space()" and "without_space()" methods
    /// </summary>
    public class TextBoxFormatter
    {

        private List<string[]> space_removed { get; set; }
        private string space_preserved { get; set; }

        // I should allow the constuctor to take data in as two forms - but that shouldn't matter.
        // I'll just run both versions of the program to homogenize the data.
        /// <summary>
        /// 
        /// </summary>
        public TextBoxFormatter()
        {

        }

        protected void eliminate_whitespace(string input)
        {

        }

        // alrighty - the inner array needs to contain words that should have spaces, while the list contains sentences that require \r\n
        protected void recreate_whitespace(List<string[]> input)
        {
            foreach(string[] a in input)
            {
                for(int i=0;i<a.Length;i++)
                {

                }
            }
        }

        public List<string[]> no_whitespace(string input)
        {
            return new List<string[]>(); // placeholder.
        }

        public string whitespace(List<string[]> input)
        {
            return ""; // placeholder
        }

    }
}
