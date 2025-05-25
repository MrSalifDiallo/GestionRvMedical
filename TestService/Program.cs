namespace TestService;
class Program
{
    static void Main()
    {
        while (true)
        {

            Console.Clear();
            string path = "menu.txt";
            string alltext = File.ReadAllText(path);
            Console.WriteLine(alltext);
            Console.Write("Votre Choix :");

            string choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                    ServiceAgenda.AgendaMethod();
                    break;
                case "2":
                    //Calculatrice.LancerCalculatrice();
                    break;
                case "3":
                    //Factorielle.CalculerFactorielle();
                    break;
                case "4":
                    //Puissance.CalculerPuissance();
                    break;
                case "5":
                    //VerificationAge.VerifierAge();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Choix invalide, appuyez sur une touche pour réessayer.");
                    Console.ReadKey();
                    break;
            }
        }
    }

}
