using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Windows.Controls;
using System.IO;

namespace MetroUI
{
    class EzConfig
    {
        static public string Path = @"EzConfig.xml";

        static public void Load()
        {
            try
            {
                /// 설정 파일 없으면 하나 만들자
                if (File.Exists(Path) == false)
                {
                    new XDocument(
                        new XElement("EzConfig",
                            new XElement("SvnInfo", 
                                new XElement("Info", new XAttribute("path", ""))
                            )
                        )
                    ).Save(Path);
                }
                else
                {
                    var infoList = XDocument.Load(Path)
                        .XPathSelectElements("//SvnInfo/Info")
                        .Select(e => e.Attribute("path").Value)
                        .ToList();

                    foreach (var info in infoList)
                    {
                        MainWindow.mainPanel.Children.Add(new SvnPanel(info));
                    }

                    MainWindow.mainPanel.Children.Add(new SvnPanel(""));
                }
            }
            catch(Exception e)
            {
            }
        }

        static public void Save(string src, string dest)
        {
            var doc = XDocument.Load(Path);
            var query = string.Format("//SvnInfo/Info[@path='{0}']", src);

            var result = doc.XPathSelectElement(query);

            if (result != null)
            {
                result.Attribute("path").Value = dest;
            }
            else
            {
                doc.XPathSelectElement("//SvnInfo")
                    .Add(new XElement("Info", new XAttribute("path", dest)));
            }

            doc.Save(Path);

            MainWindow.mainPanel.Children.Add(new SvnPanel(""));
        }
    }
}
