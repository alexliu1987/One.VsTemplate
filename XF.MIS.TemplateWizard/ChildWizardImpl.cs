using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace XF.MIS.TemplateWizard
{
    public class ChildWizardImpl : IWizard
    {
        #region IWizard Members

        public void BeforeOpeningFile(ProjectItem projectItem) { }

        public void ProjectFinishedGenerating(Project project) { }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem) { }

        public void RunFinished() { }

        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {
            string safeprojectname = RootWizardImpl.GlobalParameters.Where(p => p.Key == "$safeprojectname$").First().Value;
            replacementsDictionary["$safeprojectname$"] = safeprojectname;
        }

        public bool ShouldAddProjectItem(string filePath) { return true; }

        #endregion
    }
}
