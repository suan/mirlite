using System;
using System.Collections.Generic;
using Mirror;
using System.Text;
using System.Windows.Forms;

namespace mirlite
{
    public partial class MainForm
    {
        public VioletMirror Mirror { get; set; }
        private List<string> placedRFIDs = new List<string>();
        private List<string> prevPlacedRFIDs = new List<string>();
        private string curRFID;
        private bool isMirConnected = false;
        private bool lightsAndSoundOn = true;
        private bool safeToDisableChoreo = false;
        private XmlFile prefsXml = new XmlFile(Globals.preferencesXmlPath, Globals.preferencesRootNode);
        private XmlFile stateXml = new XmlFile(Globals.stateXmlPath, Globals.stateRootNode);

        private bool stateOverride = false;     // HACK
        private bool dontRunProgs = false;
        //private MessageBox mbReconnectWait = new MessageBox();
    }
}
