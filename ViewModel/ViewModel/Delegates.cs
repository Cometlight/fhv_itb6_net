namespace ViewModel
{
    public abstract class Delegates
    {
        // This is defined here because it's used in multiple classes
        public delegate void UnsavedChangesChangedEventHandler(object sender, bool value);
    }
}
