using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mirlite
{
    class XmlFile
    {
        public string fileName { get; set; }
        public string rootNode { get; set; }

        public XmlFile(string _fileName, string _rootNode)
        {
            fileName = _fileName;
            rootNode = _rootNode;
        }
    }
}
