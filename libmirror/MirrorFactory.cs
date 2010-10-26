using System.Collections.Generic;
using Mirror.UsbLibrary;

namespace Mirror
{
    public class MirrorFactory
    {
        /// <summary>
        /// Gets first found Mirror device. 
        /// </summary>
        /// <returns>Mirror device or null if not found</returns>
        public static DeviceDescription<VioletMirror> GetMirror()
        {
            var device = HIDDevice.FindDevice<VioletMirror>();
            return device;
        }
        public static IEnumerable<DeviceDescription<VioletMirror>> GetMirrors()
        {
            var devices = HIDDevice.FindDevices<VioletMirror>();
            return devices;
        }
    }
}