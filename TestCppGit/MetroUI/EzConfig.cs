using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MetroUI
{
    class EzConfig
    {
        static public void Load()
        {
            var  doc = XDocument.Load(@"EzConfig.xml");

            var path = doc.XPathSelectElements("//SvnPath").ToList();
        }

        static public void Save()
        {

        }
    }
}
