// Titre : convertir un nombre entier représenté en base 10 en sa représentation dans une base entière entre 2 et 36 inclusivement

// Déclarer et initialiser les constantes et la variable
string[] SYMBOLES_POUR_CONVERSION = new string[36] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
string continuer = "";

// Exécuter le bloc de code suivant, et recommencer la boucle do-while tant que la variable continuer est différente de "n"
do
{
    // Exécuter la méthode EntrerEtValiderDonnees(), puis enregistrer les valeurs de retour dans donnees. La valeur de donnees.Item1 correspond à
    // representation_initiale et la valeur de donnees.Item2 correspond à base_de_lexponentielle
    var donnees = EntrerEtValiderDonnees();

    // Exécuter la méthode CalculerEtAfficher(donnees.Item1, donnees.Item2)
    CalculerEtAfficher(donnees.Item1, donnees.Item2);

    // Exécuter la méthode ContinuerOuPas()
    continuer = ContinuerOuPas();
} while (continuer != "n");



Tuple<int, int> EntrerEtValiderDonnees()
{
    // Déclarer puis initialiser/réinitialiser les variables
    int representation_initiale = 0;
    int base_de_lexponentielle = 0;
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
            Console.WriteLine("\nCette entrée n'est pas valide. Entrez un nombre entier tel que représenté en base 10 :\n");
        }

        // S'il y a une ou des erreurs d'overflow, afficher ces messages
        catch (System.OverflowException)
        {
            // Changer la valeur de la variable validation_nombre_a_convertir si on obtient une erreur
            validation_nombre_a_convertir = false;

            // Afficher ce message
            Console.WriteLine("\nCe nombre est trop large. Entrez une valeur plus petite.\n");
        }

        // Si la valeur absolue de representation_initiale est égale à -2147483648 (soit la valeur de Int32.MaxValue convertie en nombre négatif),
        // exécuter le code suivant. Si on n'impose pas cette condition, on obtient une erreur plus tard dans l'exécution du programme
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

        // S'il y a une ou des erreurs de format, afficher ce message
        catch (FormatException)
        {
            Console.WriteLine("Cette entrée n'est pas valide.\n");
        }

        // S'il y a une ou des erreurs d'overflow, afficher ce message
        catch (System.OverflowException)
        {
            Console.WriteLine("Ce nombre est trop large.\n");
        }
    }
    while (base_de_lexponentielle < 2 || base_de_lexponentielle > 36);

    // Retourner l'objet Tuple<int, int>(representation_initiale, base_de_lexponentielle)
    return new Tuple<int, int>(representation_initiale, base_de_lexponentielle);
}

void CalculerEtAfficher(int representation_initiale, int base_de_lexponentielle)
{
    // Si la valeur de representation_initiale diffère de 0
    if (representation_initiale != 0)
    {
        // Trouver le plus gros exposant pour décomposer la valeur entrée dans la base donnée
        int plus_gros_exposant = (int)Math.Floor(Math.Log(Math.Abs(representation_initiale), base_de_lexponentielle));

        // Afficher une partie du message
        Console.WriteLine("Le nombre " + representation_initiale + " représenté en base 10 se décompose en la somme d'exponentielle(s) en base " + base_de_lexponentielle + " de la façon suivante :");

        // Si le signe du nombre à convertir est positif, afficher ce message
        if (Math.Sign(representation_initiale) == 1)
        {
            Console.WriteLine("\nLe signe du nombre est positif\n");
        }

        // Si le signe du nombre à convertir est négatif, afficher ce message
        else
        {
            Console.WriteLine("\nLe signe du nombre est négatif\n");
        }

        // Déclarer et initialiser les variables restant et representation_finale
        int restant = Math.Abs(representation_initiale);
        string representation_finale = "";

        // Pour une valeur de compteur_dexposants entre la valeur de plus_gros_exposant et de 0, exécuter le bloc de code suivant
        for (int compteur_dexposants = plus_gros_exposant; compteur_dexposants >= 0; compteur_dexposants--)
        {
            // Déclarer et initialiser la variable nombre_a_convertir_en_chiffre
            int nombre_a_convertir_en_chiffre = 0;

            // Exécuter les instructions suivantes à la condition que (restant - Math.Pow(base_de_lexponentielle, compteur_dexposants)) >= 0
            while (restant - Math.Pow(base_de_lexponentielle, compteur_dexposants) >= 0)
            {
                restant = restant - (int)Math.Pow(base_de_lexponentielle, compteur_dexposants);

                nombre_a_convertir_en_chiffre++;
            }
            
            // Afficher le résultat
            Console.WriteLine("Valeur du chiffre " + (compteur_dexposants + 1) + " -> " + SYMBOLES_POUR_CONVERSION[nombre_a_convertir_en_chiffre] + " * " + base_de_lexponentielle + "^" + compteur_dexposants);

            // Si compteur_dexposants > 0, alors afficher ce message
            if (compteur_dexposants > 0)
            {
                Console.WriteLine("+");
            }

            // Ajouter le symbole de la variable conversion_en_symbole à la fin du string representation_finale
            representation_finale = representation_finale + SYMBOLES_POUR_CONVERSION[nombre_a_convertir_en_chiffre];
        }

        // Si la valeur de representation_initiale est négative, alors on ajoute un tiret en avant de la valeur de representation_finale
        if (representation_initiale < 0)
        {
            representation_finale = "-" + representation_finale;
        }

        // Afficher la valeur de representation_finale
        Console.WriteLine("\nLe nombre " + representation_initiale + " représenté en base 10 est équivalent au nombre " +
                          representation_finale + " représenté en base " + base_de_lexponentielle + ".");
    }

    // Si la valeur de representation_initiale est 0
    else
    {
        // Afficher une partie du message
        Console.WriteLine("Le nombre 0 représenté en base 10 se décompose en la somme d'exponentielle(s) en base " + base_de_lexponentielle + " de la façon suivante :\n" +
                          "\nLe nombre ne possède pas de signe\n\nChiffre 1 -> 0 * " + base_de_lexponentielle + "^0\n" +
                          "\nLe nombre 0 représenté en base 10 est équivalent au nombre 0 représenté en base " + base_de_lexponentielle + ".");
    }
}

string ContinuerOuPas()
{
    // Afficher ce message
    Console.WriteLine("\nVoulez-vous continuer? Tapez \"n\" (pour non), puis appuyez sur la touche Entrée pour terminer le programme.");

    // Lire la réponse
    string reponse = Console.ReadLine();

    // Si la variable continuer est non vide, alors on prend le premier caractère et on le met en minuscule
    if (reponse != "")
    {
        reponse = reponse.Substring(0, 1).ToLower();
    }

    // Afficher ce message
    Console.Write("\n");

    // Retourner la valeur du string reponse
    return reponse;
}