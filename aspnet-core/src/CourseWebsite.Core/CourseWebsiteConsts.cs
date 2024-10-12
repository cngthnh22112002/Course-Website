using CourseWebsite.Debugging;

namespace CourseWebsite
{
    public class CourseWebsiteConsts
    {
        public const string LocalizationSourceName = "CourseWebsite";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "4a48484c5efd4531963ab526ca9548cc";
    }
}
