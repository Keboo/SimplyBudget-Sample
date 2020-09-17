using System;
using SimplyBudget.Services;
using System.Threading.Tasks;

namespace SimplyBudget.Test.Simulators
{
    public class DialogService : IDialogService
    {
        private Func<object, object> OnShow { get; }

        public DialogService(Func<object, object> onShow)
        {
            OnShow = onShow ?? throw new ArgumentNullException(nameof(onShow));
        }

        public Task<bool> Show(object dialog)
        {
            bool rv = OnShow(dialog) is bool boolResult && boolResult;
            return Task.FromResult(rv);
        }
    }
}
