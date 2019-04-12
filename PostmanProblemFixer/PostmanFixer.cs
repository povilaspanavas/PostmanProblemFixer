using System;
using System.Text.RegularExpressions;

namespace PostmanProblemFixer
{
    public class PostmanFixer
    {
        public static string FixCurl(string text)
        {
            // example of the request
            // curl -H 'Host: blablabla.azure-api.net'
            // -H 'Version-Code: 12.1' -H 'platform: iphone' -H 'Accept: */*' -H 'Accept-Language: en-gb' -H 'appUserAgent: Poq-Native-iOS-App'
            // -H 'User-Agent: Blablabla' --compressed
            // 'https://myurl.com/lalal'

            // remove weird quotes coming from Android phones cUrl
            text = text.Replace("“", "\"").Replace("”", "\"");

            var result = string.Empty;
            const string uriRegex = "'?((https)|(http)|(ftps|ftp)).*'?";
            var match = Regex.Match(text, uriRegex);
            if (match.Success == false)
            {
                throw new ArgumentException("Couldn't find anything uri by using this regular expression: " + uriRegex);
            }

            result = text.Replace(match.Value, String.Empty);
            result = result.Replace("curl", "curl " + match.Value);
            return result;
        }
    }
}
