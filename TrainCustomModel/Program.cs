using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.stanford.nlp.ie.crf;
using edu.stanford.nlp.sequences;
using edu.stanford.nlp.util;
using java.util;

namespace TrainCustomModel
{
    /*
     * https://medium.com/swlh/stanford-corenlp-training-your-own-custom-ner-tagger-8119cc7dfc06
     */
    class Program
    {
        static void Main(string[] args)
        {
            var propPath = @"..\..\train.prop";
            var modelPath = @"..\..\ner-model.ser.gz";

            TrainAndWrite(propPath, modelPath);

            var crf = CRFClassifier.getClassifierNoExceptions(modelPath);

            String[] tests = new String[] { "apple watch", "samsung mobile phones", " lcd 52 inch tv" };

            foreach (String item in tests)
            {
                DoTagging(crf, item);
            }

        }

        static void TrainAndWrite(string propPath, string modelPath)
        {
            Properties props = StringUtils.propFileToProperties(propPath);

            var flags = new SeqClassifierFlags(props);

            var crf = new CRFClassifier(flags);
            crf.train();
            crf.serializeClassifier(modelPath);
        }

        static void DoTagging(CRFClassifier model, String input)
        {
            input = input.Trim();

            Console.WriteLine(input + "=>" + model.classifyToString(input));
        }
    }
}
