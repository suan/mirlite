namespace Mirror
{
    // http://2.bp.blogspot.com/_NcFT1bJ_drE/SPRnEuvht3I/AAAAAAAABek/GIx05u3bGz8/s1600-h/MirrorFactoryTestTool.jpg
    public enum EventType
    {
        Unspecified = 0x0000,
        GetMirrorId = 0x0101,
        MirrorId = 0x0102,
        GetOrientation = 0x0103,
        OrientationUp = 0x0104,
        OrientationDown = 0x0105,
        EchoRequestResponse = 0x01FF, // From http://blog.nomzit.com/archives/274
        ShowTag = 0x0201,
        HideTag = 0x0202,

        // Choreo commands
        SetChoreoOff = 0x0301, // Returns 0xff32 if fails 
        UnknownChoreoCommand02 = 0x0302, 
        PlayChoreo = 0x0303, // This also reactivates choreos if them are being set off
        SetChoreoPowerOnly = 0x0304,
        UnknownChoreoCommand05 = 0x0305,
        UnknownChoreoCommand06 = 0x0306,
        GetChoreoInfo = 0x0307, // This could be Get Choreo Info where the data would be volume + heap?
        ChoreoInfo = 0x0308, // Choreo info data where first two bytes are volume and second two are heap

        // Firmware commands
        UsbUpdate = 0x0401,
        GetApplicationVersion = 0x0404,
        ApplicationVersion = 0x0405,
        GetBootloaderVersion = 0x0406,
        BootloaderVersion = 0x0407,
        EnterUsbUpdate = 0x0409,
        
        // Status messages
        InvalidParameters = 0xff01,
        UnknownCommand = 0xff02,
        Error3 = 0xff03,
        Error4 = 0xff32, // This message comes for example when trying to call set choreo off and it fails
        ExceptionInCalledMethod = 0xff33 // From http://blog.nomzit.com/archives/274
    }
}