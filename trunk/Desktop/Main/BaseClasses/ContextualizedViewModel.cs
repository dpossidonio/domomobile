namespace Main.ViewModels
{
    public class ContextualizedViewModel : BaseViewModel
    {
        protected Context CurrentContext { get; set; }
        protected IServiceManager ServiceManager { get; set; }

        public ContextualizedViewModel(Context context, IServiceManager service)
        {
            CurrentContext = context;
            ServiceManager = service;
        }
    }
}