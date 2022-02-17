namespace LJCUI
{

    /// <summary>
    /// this interface will be the main menu function to allow all MainMenu subclasses will run
    /// </summary>
    public interface IMenu
    {   
        
        void Display();

        string UserInput();
    }
}