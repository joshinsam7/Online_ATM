using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSDL_Stemming
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Stemming(String input)
        {
            // Set of suffixes
            HashSet<String> suffixes = new HashSet<String>()
                {
                  "able",
                  "al",
                  "an",
                  "ance",
                  "ant",
                  "ary",
                  "ate",
                  "ed",
                  "en",
                  "er",
                  "es",
                  "est",
                  "ful",
                  "ible",
                  "ing",
                  "ion",
                  "ish",
                  "ism",
                  "ist",
                  "ity",
                  "ive",
                  "ize",
                  "less",
                  "ly",
                  "ment",
                  "ness",
                  "ous",
                  "s",
                  "tion",
                  "y"
                };
            char separator = ' ';
            string[] words = input.Split(separator); // Create an array of the inputed words
            string result = "";
            foreach (String curr in words)
            {
                foreach (String suffix in suffixes)
                {
                    if (curr.EndsWith(suffix)) // Word has a suffix, take the root
                    {
                        int end = curr.Length - suffix.Length; // The length of the word minus the length of the suffix will be the last index of the root
                        result += curr.Substring(0, end) + " ";
                        break; // Root has been added to the reutrn string so we can exit loop
                    }
                }
            }
            result = result.Substring(0, result.Length - 1); // Remove whitespace at the end
            return result;
        }

    }
}
