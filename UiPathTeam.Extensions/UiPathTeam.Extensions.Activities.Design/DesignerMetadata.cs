using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using UiPathTeam.Extensions.Activities.Design.Designers;
using UiPathTeam.Extensions.Activities.Design.Properties;

namespace UiPathTeam.Extensions.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute = new CategoryAttribute($"{Resources.Category}");

            builder.AddCustomAttributes(typeof(AddToDictionary), categoryAttribute);
            builder.AddCustomAttributes(typeof(AddToDictionary), new DesignerAttribute(typeof(AddToDictionaryDesigner)));
            builder.AddCustomAttributes(typeof(AddToDictionary), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(RemoveFromDictionary), categoryAttribute);
            builder.AddCustomAttributes(typeof(RemoveFromDictionary), new DesignerAttribute(typeof(RemoveFromDictionaryDesigner)));
            builder.AddCustomAttributes(typeof(RemoveFromDictionary), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(DictionaryContainsKey), categoryAttribute);
            builder.AddCustomAttributes(typeof(DictionaryContainsKey), new DesignerAttribute(typeof(DictionaryContainsKeyDesigner)));
            builder.AddCustomAttributes(typeof(DictionaryContainsKey), new HelpKeywordAttribute(""));


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
