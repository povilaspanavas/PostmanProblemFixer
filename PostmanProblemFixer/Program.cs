using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PostmanProblemFixer
{
    class Program
    {
        private static List<string> _commans = new List<string> { "fix" };

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 1)
                throw new ArgumentException("You must at least provide one argument - table name");
            var arg1 = args[0];
            var text = Clipboard.GetText();
            if (!_commans.Contains(arg1.ToLower()))
            {
                throw new ArgumentException("Only fix command is implemented");
            }
            if (arg1.ToLower().Contains(_commans[0])) // fix
            {
                // example of the request
                // curl -H 'Host: blablabla.azure-api.net'
                // -H 'Version-Code: 12.1' -H 'platform: iphone' -H 'Accept: */*' -H 'Accept-Language: en-gb' -H 'appUserAgent: Poq-Native-iOS-App'
                // -H 'User-Agent: Blablabla' --compressed
                // 'https://myurl.com/lalal'

                const string hostSeparator = "'";
                var result = string.Empty;
                const string uriRegex = "'((https)|(http)|(ftps|ftp)).*'";
                var match = Regex.Match(text, uriRegex);
                if (match.Success == false)
                {
                    throw new ArgumentException("Couldn't find anything uri by using this regular expression: " + uriRegex);
                }

                result = text.Replace(match.Value, String.Empty);
                result = result.Replace("curl", "curl " + match.Value);
                Clipboard.SetText(result);
            }
        }
    }
}
