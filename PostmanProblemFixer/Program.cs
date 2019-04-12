using System;
using System.Collections.Generic;
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
                string result = PostmanFixer.FixCurl(text);
                Clipboard.SetText(result);
            }
        }
    }
}
