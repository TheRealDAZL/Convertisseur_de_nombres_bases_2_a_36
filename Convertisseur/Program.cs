// Titre : convertir un nombre entier et positif représenté en base 10 en sa représentation dans une base entière entre 2 et 36 inclusivement

// Déclarer et initialiser les variables
string[] SYMBOLES_POUR_CONVERSION = new string[36] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
string continuer = "";

// Exécuter le bloc de code suivant
do
{
    // Initialiser ou réinitialiser la valeur de la variable representation_finale
    string representation_finale = "";

    // Exécuter le bloc de code suivant, tout en cherchant pour des erreurs
    try
    {
        // Entrer le nombre à convertir
        Console.WriteLine("Entrez un nombre entier, de valeur nulle ou positive, tel que représenté en base 10 :");

        // Lire la valeur entrée
        double representation_initiale = double.Parse(Console.ReadLine());

        // Entrer la base entière dans laquelle représenter le nombre donné
        Console.WriteLine("\nEntrez une base entière et positive représentée en base 10, plus grande ou égale à 2, et plus petite ou égale à 36 :");

        // Lire la valeur entrée
        double base_de_lexponentielle = double.Parse(Console.ReadLine());

        CalculerEtAfficher(representation_initiale, representation_finale, base_de_lexponentielle);
    }

    // S'il y a une ou des erreurs de format, afficher ces messages
    catch (FormatException)
    {
        Console.WriteLine("\nCette entrée n'est pas valide.");
    }

    // S'il y a une ou des erreurs d'overflow, afficher ces messages
    catch (System.OverflowException)
    {
        // Référence : Microsoft - Double.MaxValue Field : https://learn.microsoft.com/en-us/dotnet/api/system.double.maxvalue?view=net-7.0
        Console.WriteLine("\nCe nombre est trop gros. Entrez une valeur plus petite ou égale à 1,7976931348623157 * 10^308, et plus grande ou égale à 0.");
    }

    // Afficher le message
    Console.WriteLine("\nVoulez-vous continuer? Tapez la commande non, puis appuyez sur la touche Entrée pour terminer le programme.");

    // Lire la réponse
    continuer = Console.ReadLine().Substring(0, 1).ToLower();

    // Afficher le message
    Console.WriteLine("\n");

} while (continuer != "n"); // Continuer la boucle do-while tant que la variable quitter est différente de non



void CalculerEtAfficher(double representation_initiale, string representation_finale, double base_de_lexponentielle)
{
    // Déclarer les variables
    int plus_gros_exposant;
    int restant;
    int chiffre_pour_conversion;
    int position_du_chiffre;

    // Si la base entrée correspond aux conditions données, alors on exécute le bloc de code suivant
    // Référence : Microsoft - Math.Floor Method https://learn.microsoft.com/en-us/dotnet/api/system.math.floor?view=net-7.0
    if (base_de_lexponentielle >= 2 && base_de_lexponentielle <= 36 && base_de_lexponentielle - Math.Floor(base_de_lexponentielle) == 0)
    {
        // Si le nombre entré correspond aux conditions données, alors on exécute le bloc de code suivant
        if (representation_initiale > 0 && representation_initiale - Math.Floor(representation_initiale) == 0)
        {
            // Trouver le plus gros exposant pour décomposer la valeur entrée dans la base donnée
            // Référence : Microsoft - Math.Log Method https://learn.microsoft.com/en-us/dotnet/api/system.math.log2?view=net-7.0
            plus_gros_exposant = (int)Math.Floor(Math.Log(representation_initiale, base_de_lexponentielle));

            // Afficher une partie du message
            // Référence : GeeksforGeeks - Program to Print a New Line in C# https://www.geeksforgeeks.org/program-to-print-a-new-line-in-c-sharp/
            Console.WriteLine("\nLe nombre " + representation_initiale + " représenté en base 10 se décompose en la somme d'exponentielle(s) en base " + base_de_lexponentielle + " de la façon suivante :");

            // Initialiser la variable restant
            restant = (int)representation_initiale;

            // Pour i compris entre le plus_gros_exposant et 0, exécuter le bloc de code suivant
            // Référence : W3Schools - C# For Loop https://www.w3schools.com/cs/cs_for_loop.php
            for (int compteur_dexposants = plus_gros_exposant; compteur_dexposants >= 0; compteur_dexposants--)
            {
                // Pour tout (restant - Math.Pow(base_de_lexponentielle, i)) >= 0, exécuter l'instruction suivante
                for (chiffre_pour_conversion = 0; restant - Math.Pow(base_de_lexponentielle, compteur_dexposants) >= 0; chiffre_pour_conversion++)
                {
                    restant = restant - (int)Math.Pow(base_de_lexponentielle, compteur_dexposants);
                }

                // Définir ou redéfinir la variable position_du_chiffre
                position_du_chiffre = compteur_dexposants + 1;

                // Afficher le résultat
                Console.WriteLine("Chiffre " + position_du_chiffre + " -> " + SYMBOLES_POUR_CONVERSION[chiffre_pour_conversion]);

                // Si i > 0, alors afficher ce message
                if (compteur_dexposants > 0)
                {
                    Console.WriteLine("+");
                }

                // Ajouter le symbole de la variable conversion_en_symbole à la fin du string representation_finale
                // Référence : Stack Overflow - Convert int to string? https://stackoverflow.com/questions/3081916/convert-int-to-string
                representation_finale = representation_finale + SYMBOLES_POUR_CONVERSION[chiffre_pour_conversion];
            }

            // Afficher la variable representation_finale
            Console.WriteLine("\nLe nombre " + representation_initiale + " représenté en base 10 est équivalent au nombre " + representation_finale + " représenté en base " + base_de_lexponentielle + ".");
        }

        else if (representation_initiale == 0)
        {
            // Afficher une partie du message
            // Référence : GeeksforGeeks - Program to Print a New Line in C# https://www.geeksforgeeks.org/program-to-print-a-new-line-in-c-sharp/
            Console.WriteLine("\nLe nombre 0 représenté en base 10 se décompose en la somme d'exponentielle(s) en base " + base_de_lexponentielle + " de la façon suivante :");
            
            // Afficher le résultat
            Console.WriteLine("Chiffre 1 -> 0");

            // Afficher la variable representation_finale
            Console.WriteLine("\nLe nombre 0 représenté en base 10 est équivalent au nombre 0 représenté en base " + base_de_lexponentielle + ".");
        }

        // Sinon, afficher ce message
        else
        {
            Console.WriteLine("\nCette entrée n'est pas valide.");
        }
    }

    // Sinon, afficher ce message
    else
    {
        Console.WriteLine("\nCette entrée n'est pas valide.");
    }
}