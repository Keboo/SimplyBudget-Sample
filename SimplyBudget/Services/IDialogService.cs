using System.Threading.Tasks;

namespace SimplyBudget.Services
{
    public interface IDialogService
    {
        Task<bool> Show(object dialog);
    }
}
