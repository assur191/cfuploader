using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CFUploader.RegExFilters
{
    public static class NameFilter
    {
        //private string _composer;

        //public Hashtable names { get; set; }
        //public bool Matched { get; set; }

        public static Hashtable GetNames(string name) 
        {
            string _composer = name.Trim();
            Hashtable names = new Hashtable();            
            GroupCollection groups;
            bool Matched = false;

            if (_composer.Contains(","))
            {
                string pattern = "^([a-zA-Z\\s]+),{1}\\s?([a-zA-Z]+)\\s?([a-zA-Z\\s]*)\\s?";
                Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matches = rg.Matches(_composer);
                groups = matches[0].Groups;

                if (groups.Count > 0)
                {
			        for (int i = 1; i <= groups.Count; i++){
				        switch (i) {
				          case 1:
					          names.Add("last_name", groups[1].Value.Trim());
				              break;
				          case 2:
                              names.Add("first_name", groups[2].Value.Trim());
				              break;
				          case 3:
                              if (groups[3].Value.Trim().Length != 0)
                                  names.Add("middle_name", groups[3].Value.Trim());					  	  
					          break;
				          default:
					          Matched = false;
				              break;
				        }
			        }
                }
            }   else 
            {
                string patternLast = "([a-zA-Z]+)$";
                string patternFirst = "(^[a-zA-Z]+)";
                Regex rgLast = new Regex(patternLast, RegexOptions.IgnoreCase);
                Regex rgFirst = new Regex(patternFirst, RegexOptions.IgnoreCase);
                Match match = rgLast.Match(_composer);

                if (match.Success)
                {
                    groups = match.Groups;
                    names.Add("last_name", groups[0].Value.Trim());

                    _composer = _composer.Remove(match.Index).Trim();
                    match = rgFirst.Match(_composer);

                    if (match.Success)
                    {
                        groups = match.Groups;
                        names.Add("first_name", groups[0].Value.Trim());

                        names.Add("middle_name", _composer.Remove(0, match.Length).Trim());
                    }
                }
                else 
                {
                    Matched = false;
                }
            } 
           
            return names;
        }
    }
}
