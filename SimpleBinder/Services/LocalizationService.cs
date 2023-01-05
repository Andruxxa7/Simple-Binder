using System.ComponentModel;
using System.Linq;

namespace SimpleBinder
{
    public partial class SimpleBinder
    {
        private void ChangeLanguage(string lang)
        {
            if(lang == currentLanguage)return;
            currentLanguage = lang;
            var newLangCultureInfo = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = newLangCultureInfo;
            Thread.CurrentThread.CurrentUICulture = newLangCultureInfo;

            #region ApplyingResources
            {
                var resources = new ComponentResourceManager(typeof(SimpleBinder));
                foreach (Control control in Controls)
                {
                    resources.ApplyResources(control, control.Name, newLangCultureInfo);
                }

                foreach (var label in Controls.OfType<Label>())
                {
                    resources.ApplyResources(label,label.Name,newLangCultureInfo);
                }
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    resources.ApplyResources(item, item.Name, newLangCultureInfo);
                    foreach (ToolStripMenuItem dropItem in item.DropDownItems)
                    {
                        resources.ApplyResources(dropItem, dropItem.Name, newLangCultureInfo);
                    }
                }
                resources.ApplyResources(this, "$this",newLangCultureInfo);
            }
            #endregion
        }
        
        
    }

    #region LanguageToolStripItems

    

    #endregion
}