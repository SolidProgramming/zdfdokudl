using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zdfdokudl_downloader.Classes
{
    internal static class Misc
    {
        internal static Dictionary<string, DocuTopicType> AllowedDocuTopics = new()
        {
            { "27d082ef-707c-4133-94cb-3410c9efd0ef", DocuTopicType.NewDocu },
            { "bdec7ee6-3280-4514-b15e-0da04cc2cf5a", DocuTopicType.HumansAndLife },
            { "08c2f76b-4cc5-44bf-b2ad-d1f1e173cebd", DocuTopicType.NatureAndAnimals },
            { "a7f46711-5621-4ec9-b124-5da6e3d9f378", DocuTopicType.History },
            { "0bfdb373-6270-4dd6-8675-c7f37169accf", DocuTopicType.Science },
            { "3d64a2bc-3976-4290-8820-60a1347f4956", DocuTopicType.Traveling },
            { "11d1099b-5b11-413d-856e-2fbd7f2689bc", DocuTopicType.Architecture },
            { "053c5fa8-b244-4a5c-b96e-c297d118def5", DocuTopicType.Archeology },
            { "27778835-660a-480d-8707-c6c5ad160d07", DocuTopicType.Space },
            { "0ce2cd3a-6e25-4730-9d5a-c3c2e90c86c0", DocuTopicType.FunkTRU }
        };

        internal static Dictionary<string, DocuTopicType> DocuNames = new()
        {
            { "Neue Dokus und Reportagen", DocuTopicType.NewDocu },
            { "Menschen und Leben", DocuTopicType.HumansAndLife },
            { "Natur und Tiere", DocuTopicType.NatureAndAnimals },
            { "Geschichte", DocuTopicType.History },
            { "Wissenschaft", DocuTopicType.Science },
            { "Reise", DocuTopicType.Traveling },
            { "Architektur", DocuTopicType.Architecture },
            { "Archäologie", DocuTopicType.Archeology },
            { "Weltraum", DocuTopicType.Space },
            { "funk - TRU DOKU", DocuTopicType.FunkTRU }
        };

        internal static List<ZDFTeaser> Filter(this List<ZDFTeaser> list)
        {
            return list.Where(_ => AllowedDocuTopics.ContainsKey(_.Title)).ToList();
        }

        internal static string ToDocuName()
        {
            throw new NotImplementedException();
        }

        internal static DocuTopicType ToTopicType()
        {
            throw new NotImplementedException();
        }
    }
}
