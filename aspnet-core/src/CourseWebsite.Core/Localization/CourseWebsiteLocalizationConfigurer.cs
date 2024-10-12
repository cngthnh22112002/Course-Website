using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace CourseWebsite.Localization
{
    public static class CourseWebsiteLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(CourseWebsiteConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(CourseWebsiteLocalizationConfigurer).GetAssembly(),
                        "CourseWebsite.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
