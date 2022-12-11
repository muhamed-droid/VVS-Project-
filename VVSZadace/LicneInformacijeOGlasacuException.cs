using System;
using System.Runtime.Serialization;

namespace VVSZadace
{
    [Serializable]
    public class LicneInformacijeOGlasacuException : Exception
    {
        public LicneInformacijeOGlasacuException()
        {
        }

        public LicneInformacijeOGlasacuException(string message) : base(message)
        {
        }

        public LicneInformacijeOGlasacuException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LicneInformacijeOGlasacuException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}