using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mirlite
{
    public class Globals
    {
        public static String xmlFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\mirlite";
        public static String thingsXmlPath = xmlFolder + @"\Things.xml";
        public static String programsXmlPath = xmlFolder + @"\Programs.xml";

        public static String preferencesXmlPath = xmlFolder + @"\Preferences.xml";
        public static String preferencesRootNode = "Preferences";
        public static String stateXmlPath = xmlFolder + @"\States.xml";
        public static String stateRootNode = "States";

        public static String errorTitle = "mir:lite Error";
        public static String genericTitle = "mir:lite";
    }
}
