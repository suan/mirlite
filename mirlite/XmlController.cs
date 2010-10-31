using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace mirlite
{
    public partial class MainForm
    {
        public void createXmls()
        {
            dsThingPrograms.things.AddthingsRow("When mir:ror Connected", "mirConnected");
            dsThingPrograms.things.AddthingsRow("When mir:ror Disconnected", "mirDisconnected");
            dsThingPrograms.things.WriteXml(Globals.thingsXmlPath, System.Data.XmlWriteMode.WriteSchema);
        }

        private void updateXmlNode(XmlFile xml, string nodeName, object value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xml.fileName);
            XmlNode node = xmlDoc.SelectSingleNode(xml.rootNode + '/' + nodeName);
            if (value is Boolean)
            {
                node.InnerText = XmlConvert.ToString((bool)value);
            }
            xmlDoc.Save(xml.fileName);
        }

        public Boolean xmlsExist()
        {
            return (File.Exists(Globals.thingsXmlPath) && File.Exists(Globals.programsXmlPath));
        }

        public void loadData()
        {
            dsThingPrograms.things.ReadXml(Globals.thingsXmlPath);
            dsThingPrograms.programs.ReadXml(Globals.programsXmlPath);
        }

        // be careful - have to read nodes in the order they are written!
        private void loadPreferences(XmlFile prefsXml)
        {
            XmlTextReader textReader = new XmlTextReader(prefsXml.fileName);
            textReader.ReadToFollowing("minimizeToSystemTray");
            minimizePref.Checked = textReader.ReadElementContentAsBoolean();
            textReader.Close();
        }
        private void loadState(XmlFile stateXml)
        {
            XmlTextReader textReader = new XmlTextReader(stateXml.fileName);
            textReader.ReadToFollowing("lightsAndSoundOn");
            lightsAndSoundOn = textReader.ReadElementContentAsBoolean();
            textReader.ReadToFollowing("safeToDisableChoreo");
            safeToDisableChoreo = textReader.ReadElementContentAsBoolean();
            textReader.Close();
        }

        private void writeState(XmlFile stateXml)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter textWriter = XmlWriter.Create(stateXml.fileName, settings);

            textWriter.WriteStartDocument();

            textWriter.WriteStartElement(stateXml.rootNode);
                textWriter.WriteStartElement("lightsAndSoundOn", "");
                    textWriter.WriteString(XmlConvert.ToString(lightsAndSoundOn));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("safeToDisableChoreo", "");
                    textWriter.WriteString(XmlConvert.ToString(safeToDisableChoreo));
                textWriter.WriteEndElement();
            textWriter.WriteEndElement();
            textWriter.WriteEndDocument();

            textWriter.Close();
        }

        private void writePreferences(XmlFile prefsXml)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter textWriter = XmlWriter.Create(prefsXml.fileName, settings);

            textWriter.WriteStartDocument();

            textWriter.WriteStartElement(prefsXml.rootNode);
                textWriter.WriteStartElement("minimizeToSystemTray", "");
                    textWriter.WriteString(XmlConvert.ToString(minimizePref.Checked));
                textWriter.WriteEndElement();
            textWriter.WriteEndElement();
            textWriter.WriteEndDocument();

            textWriter.Close();
        }

    }
}
