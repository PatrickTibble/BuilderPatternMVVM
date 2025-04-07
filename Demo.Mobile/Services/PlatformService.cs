using Demo.Abstraction.Services;

namespace Demo.Mobile.Services
{
    internal class PlatformService : IPlatformService
    {
        public Version PlatformVersion => DeviceInfo.Version;
    }
}
