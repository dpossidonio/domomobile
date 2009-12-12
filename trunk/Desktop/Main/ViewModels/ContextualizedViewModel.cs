namespace Main.ViewModels
{
    public class ContextualizedViewModel : BaseViewModel
    {
        protected Context CurrentContext { get; set; }

        public ContextualizedViewModel(Context context)
        {
            CurrentContext = context;
        }
    }
}