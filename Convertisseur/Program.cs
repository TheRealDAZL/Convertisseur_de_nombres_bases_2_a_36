// Titre : convertir un nombre entier représenté en base 10 en sa représentation dans une base entière entre 2 et 36 inclusivement

// Déclarer et initialiser les constantes et la variable
string[] SYMBOLES_POUR_CONVERSION = new string[36] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
string continuer = "";

// Exécuter le bloc de code suivant, et recommencer la boucle do-while tant que la variable booléene validation_nombre_a_convertir a la valeur faux
do
{
    // Déclarer puis initialiser/réinitialiser les variables
    int representation_initiale = -1;
    int base_de_lexponentielle = -1;
    bool validation_nombre_a_convertir = true;

    // Exécuter le bloc de code suivant
    do
    {
        // Exécuter le bloc de code suivant, tout en cherchant pour des erreurs
        try
        {
            // Réinitialiser la variable
            validation_nombre_a_convertir = true;

            // Entrer le nombre à convertir
            Console.WriteLine("Entrez un nombre entier tel que représenté en base 10 :");

            // Lire la valeur entrée
            representation_initiale = int.Parse(Console.ReadLine());

            // Afficher ce message
            Console.Write("\n");
        }

        // S'il y a une ou des erreurs de format, afficher ces messages
        catch (FormatException)
        {
            // Changer la valeur de la variable validation_nombre_a_convertir si on obtient une erreur
            validation_nombre_a_convertir = false;

            // Afficher ce message
            Console.WriteLine("\nCette entrée n'est pas valide.\n");
        }

        // S'il y a une ou des erreurs d'overflow, afficher ces messages
        catch (System.OverflowException)
        {
            // Changer la valeur de la variable validation_nombre_a_convertir si on obtient une erreur
            validation_nombre_a_convertir = false;

            // Afficher ce message
            Console.WriteLine("\nCe nombre est trop large. Entrez une valeur plus petite.\n");
        }

        // Si la valeur absolue de representation_initiale est égale à -2147483648 (soit la valeur Int32.MinValue),
        // exécuter le code suivant. Si on ne fait pas ça, on obtient une erreur plus tard dans l'exécution du programme
        if (representation_initiale == -2147483648)
        {
            // Changer la valeur de la variable validation_nombre_a_convertir si on obtient une erreur
            validation_nombre_a_convertir = false;

            // Afficher ce message
            Console.WriteLine("Ce nombre est trop large. Entrez une valeur plus petite.\n");
        }
    }
    while (!validation_nombre_a_convertir);

    // Exécuter le bloc de code suivant
    do
    {
        // Exécuter le bloc de code suivant, tout en cherchant pour des erreurs
        try
        {
            // Entrer la base entière dans laquelle représenter le nombre donné
            Console.WriteLine("Entrez une base entière et positive représentée en base 10, plus grande ou égale à 2, et plus petite ou égale à 36 :");

            // Lire la valeur entrée
            base_de_lexponentielle = int.Parse(Console.ReadLine());

            // Afficher ce message
            Console.Write("\n");
        }

        // S'il y a une ou des erreurs de format, afficher ces messages
        catch (FormatException)
        {
            Console.WriteLine("Cette entrée n'est pas valide.\n");
        }

        // S'il y a une ou des erreurs d'overflow, afficher ces messages
        catch (System.OverflowException)
        {
            // Référence : Microsoft - Double.MaxValue Field : https://learn.microsoft.com/en-us/dotnet/api/system.double.maxvalue?view=net-7.0
            Console.WriteLine("Ce nombre est trop gros. Entrez une valeur plus petite ou égale à 1,7976931348623157 * 10^308, et plus grande ou égale à 0.\n");
        }
    }
    while (base_de_lexponentielle < 2 || base_de_lexponentielle > 36);

    // Exécuter la méthode CalculerEtAfficher
    CalculerEtAfficher(representation_initiale, base_de_lexponentielle);

    // Afficher ce message
    Console.WriteLine("\nVoulez-vous continuer? Tapez \"n\" (pour non), puis appuyez sur la touche Entrée pour terminer le programme.");

    // Lire la réponse
    continuer = Console.ReadLine();

    // Si la variable continuer est non vide, alors on prend le premier caractère et on le met en minuscule
    if (continuer != "")
    {
        continuer = continuer.Substring(0, 1).ToLower();
    }

    // Afficher ce message
    Console.Write("\n");
} while (continuer != "n"); // Continuer la boucle do-while tant que la variable quitter est différente de non



void CalculerEtAfficher(int representation_initiale, int base_de_lexponentielle)
{
    // Déclarer et/ou initialiser les variables
    int plus_gros_exposant;
    int restant;
    int chiffre_a_convertir;
    int position_du_chiffre;
    string representation_finale = "";

    // Si le nombre entré correspond aux conditions données, alors on exécute le bloc de code suivant
    if (representation_initiale != 0)
    {
        if (representation_initiale > 0)
        {
            // Trouver le plus gros exposant pour décomposer la valeur entrée dans la base donnée
            // Référence : Microsoft - Math.Log Method https://learn.microsoft.com/en-us/dotnet/api/system.math.log2?view=net-7.0
            plus_gros_exposant = (int)Math.Floor(Math.Log(representation_initiale, base_de_lexponentielle));
        }

        else
        {
            // Trouver le plus gros exposant pour décomposer la valeur entrée dans la base donnée
            // Référence : Microsoft - Math.Log Method https://learn.microsoft.com/en-us/dotnet/api/system.math.log2?view=net-7.0
            plus_gros_exposant = (int)Math.Floor(Math.Log(-representation_initiale, base_de_lexponentielle));
        }

        // Afficher une partie du message
        // Référence : GeeksforGeeks - Program to Print a New Line in C# https://www.geeksforgeeks.org/program-to-print-a-new-line-in-c-sharp/
        Console.WriteLine("Le nombre " + representation_initiale + " représenté en base 10 se décompose en la somme d'exponentielle(s) en base " + base_de_lexponentielle + " de la façon suivante :");

        if (representation_initiale > 0)
        {
            // Initialiser la variable restant
            restant = representation_initiale;
        }

        else
        {
            // Initialiser la variable restant
            restant = -representation_initiale;
        }

        // Pour i compris entre le plus_gros_exposant et 0, exécuter le bloc de code suivant
        // Référence : W3Schools - C# For Loop https://www.w3schools.com/cs/cs_for_loop.php
        for (int compteur_dexposants = plus_gros_exposant; compteur_dexposants >= 0; compteur_dexposants--)
        {
            // Pour tout (restant - Math.Pow(base_de_lexponentielle, i)) >= 0, exécuter l'instruction suivante
            for (chiffre_a_convertir = 0; restant - Math.Pow(base_de_lexponentielle, compteur_dexposants) >= 0; chiffre_a_convertir++)
            {
                restant = restant - (int)Math.Pow(base_de_lexponentielle, compteur_dexposants);
            }

            // Définir ou redéfinir la variable position_du_chiffre
            position_du_chiffre = compteur_dexposants + 1;

            if (representation_initiale > 0)
            {
                // Afficher le résultat
                Console.WriteLine("Chiffre " + position_du_chiffre + " -> (+1) * " + SYMBOLES_POUR_CONVERSION[chiffre_a_convertir]);
            }

            else
            {
                // Afficher le résultat
                Console.WriteLine("Chiffre " + position_du_chiffre + " -> (-1) * " + SYMBOLES_POUR_CONVERSION[chiffre_a_convertir]);
            }

            // Si i > 0, alors afficher ce message
            if (compteur_dexposants > 0)
            {
                Console.WriteLine("+");
            }

            // Ajouter le symbole de la variable conversion_en_symbole à la fin du string representation_finale
            // Référence : Stack Overflow - Convert int to string? https://stackoverflow.com/questions/3081916/convert-int-to-string
            representation_finale = representation_finale + SYMBOLES_POUR_CONVERSION[chiffre_a_convertir];
        }

        if (representation_initiale > 0)
        {
            // Afficher la variable representation_finale
            Console.WriteLine("\nLe nombre " + representation_initiale + " représenté en base 10 est équivalent au nombre " + representation_finale + " représenté en base " + base_de_lexponentielle + ".");
        }

        else
        {
            // Afficher la variable representation_finale
            Console.WriteLine("\nLe nombre " + representation_initiale + " représenté en base 10 est équivalent au nombre -" + representation_finale + " représenté en base " + base_de_lexponentielle + ".");
        }
    }

    else
    {
        // Afficher une partie du message
        // Référence : GeeksforGeeks - Program to Print a New Line in C# https://www.geeksforgeeks.org/program-to-print-a-new-line-in-c-sharp/
        Console.WriteLine("Le nombre 0 représenté en base 10 se décompose en la somme d'exponentielle(s) en base " + base_de_lexponentielle + " de la façon suivante :");

        // Afficher le résultat
        Console.WriteLine("Chiffre 1 -> 0");

        // Afficher la variable representation_finale
        Console.WriteLine("\nLe nombre 0 représenté en base 10 est équivalent au nombre 0 représenté en base " + base_de_lexponentielle + ".");
    }
}