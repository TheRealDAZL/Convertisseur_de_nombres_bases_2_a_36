// Titre : convertir un nombre entier et positif représenté en base 10 en sa représentation dans une base entière entre 2 et 36 inclusivement

// Déclarer les variables 
double representation_initiale;
double base_de_lexponentielle;
double restant;
double plus_gros_exposant;
double multiplicateur_de_la_base;
double position_du_chiffre;
string[] conversion_en_symbole = new string[36] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
string representation_finale;
string continuer;

// Initialiser la valeur de la variable quitter
continuer = "";

// Exécuter le bloc de code suivant
do
{
    // Initialiser ou réinitialiser la valeur de la variable representation_finale
    representation_finale = "";

    // Exécuter le bloc de code suivant, tout en cherchant pour des erreurs
    try
    {
        // Entrer le nombre à convertir
        Console.WriteLine("Entrez un nombre entier et positif, représenté en base 10 :");

        // Lire la valeur entrée
        representation_initiale = double.Parse(Console.ReadLine());

        // Entrer la base entière dans laquelle représenter le nombre donné
        Console.WriteLine("\nEntrez une base entière et positive représentée en base 10, plus grande ou égale à 2, et plus petite ou égale à 36 :");

        // Lire la valeur entrée
        base_de_lexponentielle = double.Parse(Console.ReadLine());

        // Si la base entrée correspond aux conditions données, alors on exécute le bloc de code suivant
        // Référence : Microsoft - Math.Floor Method https://learn.microsoft.com/en-us/dotnet/api/system.math.floor?view=net-7.0
        if (base_de_lexponentielle >= 2 && base_de_lexponentielle <= 36 && base_de_lexponentielle - Math.Floor(base_de_lexponentielle) == 0)
        {
            // Si le nombre entré correspond aux conditions données, alors on exécute le bloc de code suivant
            if (representation_initiale > 0 && representation_initiale - Math.Floor(representation_initiale) == 0)
            {
                // Trouver le plus gros exposant pour décomposer la valeur entrée dans la base donnée
                // Référence : Microsoft - Math.Log Method https://learn.microsoft.com/en-us/dotnet/api/system.math.log2?view=net-7.0
                plus_gros_exposant = Math.Floor(Math.Log(representation_initiale, base_de_lexponentielle));

                // Afficher une partie du message
                // Référence : GeeksforGeeks - Program to Print a New Line in C# https://www.geeksforgeeks.org/program-to-print-a-new-line-in-c-sharp/
                Console.WriteLine("\nLe nombre " + representation_initiale + " représenté en base 10 se décompose en la somme d'exponentielle(s) en base " + base_de_lexponentielle + " de la façon suivante :");

                // Initialiser la variable restant
                restant = representation_initiale;

                // Pour i compris entre le plus_gros_exposant et 0, exécuter le bloc de code suivant
                // Référence : W3Schools - C# For Loop https://www.w3schools.com/cs/cs_for_loop.php
                for (double i = plus_gros_exposant; i >= 0; i = i - 1)
                {
                    // Pour tout (restant - Math.Pow(base_de_lexponentielle, i)) >= 0, exécuter l'instruction suivante
                    for (multiplicateur_de_la_base = 0; restant - Math.Pow(base_de_lexponentielle, i) >= 0; multiplicateur_de_la_base += 1)
                    {
                        restant = restant - Math.Pow(base_de_lexponentielle, i);
                    }

                    // Définir ou redéfinir la variable position_du_chiffre
                    position_du_chiffre = i + 1;

                    // Déclarer, puis initialiser la variable
                    int j = (int)multiplicateur_de_la_base;

                    // Afficher le résultat
                    Console.WriteLine("Chiffre " + position_du_chiffre + " -> " + conversion_en_symbole[j]);

                    // Si i > 0, alors afficher ce message
                    if (i > 0)
                    {
                        Console.WriteLine("+");
                    }

                    // Ajouter le symbole de la variable conversion_en_symbole à la fin du string representation_finale
                    // Référence : Stack Overflow - Convert int to string? https://stackoverflow.com/questions/3081916/convert-int-to-string
                    representation_finale = representation_finale + conversion_en_symbole[j];
                }

                // Afficher la variable representation_finale
                Console.WriteLine("\nLe nombre " + representation_initiale + " représenté en base 10 est équivalent au nombre " + representation_finale + " représenté en base " + base_de_lexponentielle + ".");
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
    continuer = Console.ReadLine();

    // Afficher le message
    Console.WriteLine("\n");

} while (continuer != "non"); // Continuer la boucle do-while tant que la variable quitter est différente de non