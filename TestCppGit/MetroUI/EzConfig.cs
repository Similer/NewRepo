using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Windows.Controls;

namespace MetroUI
{
    class EzConfig
    {
        static public void Load(ref StackPanel stackPanel)
        {
            try
            {
                var doc = XDocument.Load(@"EzConfig.xml");

                var infoList = doc
                    .XPathSelectElements("//SvnInfo/Info")
                    .Select(e => e.Attribute("path").Value)
                    .ToList();

                foreach (var info in infoList)
                {
                    stackPanel.Children.Add(new SvnPanel(info));
                }
            }
            catch(Exception e)
            {
            }
        }

        static public void Save()
        {

        }
    }
}
