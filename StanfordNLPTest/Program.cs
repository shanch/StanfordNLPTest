using System;
using edu.stanford.nlp.ie.crf;

namespace StanfordNLPTest
{
    /*
     * https://sergey-tihon.github.io/Stanford.NLP.NET/StanfordCoreNLP.html
     */
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the folder with classifiers models
            var jarRoot = @"..\..\..\stanford-ner-2016-10-31";
            var classifiersDirecrory = jarRoot + @"\classifiers";

            // Loading 3 class classifier model
            var classifier = CRFClassifier.getClassifierNoExceptions(
                classifiersDirecrory + @"\english.all.3class.distsim.crf.ser.gz");

            var s1 = "Good afternoon Rajat Raina, how are you today?";
            Console.WriteLine("{0}\n", classifier.classifyToString(s1));

            var s2 = "I go to school at Stanford University, which is located in California.";
            Console.WriteLine("{0}\n", classifier.classifyWithInlineXML(s2));

            Console.WriteLine("{0}\n", classifier.classifyToString(s2, "xml", true));
        }
    }
}
