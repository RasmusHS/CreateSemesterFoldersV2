using CreateSemesterFoldersV2.Interfaces;
using CreateSemesterFoldersV2.Interfaces.Implementation;

namespace CreateSemesterFoldersV2
{
    public class Program
    {
        public static void Main()
        {
            ICheckIfInt validate = new CheckIfInt();
            ICreateFolders createFolders = new CreateFolders();
            bool fortsæt = false;
            do
            {
                Console.Write("Indtast første ugenummer for semestret: ");
                string input = Console.ReadLine();
                int startUge = validate.Validate(input);

                Console.Write("Indtast sidste ugenummer for semestret: ");
                input = Console.ReadLine();
                int slutUge = validate.Validate(input);

                Console.Write("Indtast hele stien til den ønskede placering for mapperne: ");
                input = Console.ReadLine();
                string sti = validate.ValidatePath(input);

                createFolders.Create(startUge, slutUge, sti);

                Console.Write("Lav flere mapper? (J/N): ");
                input = Console.ReadLine().ToUpper();
                if (input == "J")
                    fortsæt = true;
                else
                    fortsæt = false;

            } while (fortsæt);
            
        }
    }
}