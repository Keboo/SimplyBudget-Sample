using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;

namespace SimplyBudget.Services
{
    public class DialogService : IDialogService
    {
        public async Task<bool> Show(object dialog)
        {
            return await DialogHost.Show(dialog) is bool boolResult 
                   && boolResult;
        }
    }
}