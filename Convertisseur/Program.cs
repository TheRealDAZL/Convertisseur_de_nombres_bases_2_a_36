// Titre : convertir un nombre entier représenté en base 10 en sa représentation dans une base entière entre 2 et 36 inclusivement



// Déclarer et initialiser la variable
string continuer = "";

// Exécuter le bloc de code suivant, et recommencer la boucle do-while tant que la variable continuer est différente de "n"
do
{
    // Exécuter la méthode EntrerEtValiderDonnees(), puis enregistrer les valeurs de retour dans donnees. La valeur de donnees.Item1 correspond à
    // representation_initiale et la valeur de donnees.Item2 correspond à base_de_lexponentielle
    var donnees_entrees = EntrerEtValiderDonnees();

    // Exécuter la méthode IsolerPlusGrosExposant(donnees_entrees.Item1, donnees_entrees.Item2), puis enregistrer la valeur de retour dans exposant_max
    int exposant_max = IsolerPlusGrosExposant(donnees_entrees.Item1, donnees_entrees.Item2);

    // Exécuter la méthode ConvertirEtAfficher(donnees.Item1, donnees.Item2, exposant_max)
    ConvertirEtAfficher(donnees_entrees.Item1, donnees_entrees.Item2, exposant_max);

    // Exécuter la méthode ContinuerOuPas(), puis enregistrer la valeur de retour dans continuer
    continuer = ContinuerOuPas();
} while (continuer != "n");


// Entrer des données, puis les valider
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

// Trouver le plus gros exposant entier, afin de décomposer la valeur entrée dans la base donnée
int IsolerPlusGrosExposant(int representation_initiale, int base_de_lexponentielle)
{
    // Si la valeur de representation_initiale est différente de 0
    if (representation_initiale != 0)
    {
        // Déclarer et initialiser les variables
        int valeur_absolue = Math.Abs(representation_initiale);
        int exposant = 0;

        // Tant que Math.Pow(base_de_lexponentielle, exposant) < valeur_absolue, additionner la valeur 1
        // à la valeur de exposant
        while (Math.Pow(base_de_lexponentielle, exposant) < valeur_absolue)
        {
            exposant++;
        }

        // Si la valeur de Math.Pow(base_de_lexponentielle, exposant) est différente de valeur_absolue,
        // retourner exposant - 1
        if (Math.Pow(base_de_lexponentielle, exposant) != valeur_absolue)
        {
            return exposant - 1;
        }

        // Si la valeur de Math.Pow(base_de_lexponentielle, exposant) est égale à valeur_absolue,
        // retourner exposant
        return exposant;
    }

    // Si la valeur de representation_initiale est égale à 0, retourner 0
    else
    {
        return 0;
    }
}

// Décomposer le nombre dans la base donnée, puis afficher les résultats
void ConvertirEtAfficher(int representation_initiale, int base_de_lexponentielle, int plus_gros_exposant_entier)
{
    // Déclarer et initialiser les constantes
    string[] SYMBOLES_POUR_CONVERSION = new string[36] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    // Si le signe du nombre à convertir est positif, afficher ce message
    if (representation_initiale > 0)
    {
        Console.WriteLine("Le signe du nombre " + representation_initiale + " représenté en base 10 est positif, et il se décompose en la somme d'exponentielle(s) en base " + base_de_lexponentielle + " de la façon suivante :\n");
    }

    // Si le signe du nombre à convertir est négatif, afficher ce message
    else if (representation_initiale < 0)
    {
        Console.WriteLine("Le signe du nombre " + representation_initiale + " représenté en base 10 est négatif, et il se décompose en la somme d'exponentielle(s) en base " + base_de_lexponentielle + " de la façon suivante :\n");
    }
    
    // Si le nombre n'a pas de signe, afficher ce message
    else
    {
        Console.WriteLine("Le nombre " + representation_initiale + " représenté en base 10 ne possède pas de signe, et il se décompose en la somme d'exponentielle(s) en base " + base_de_lexponentielle + " de la façon suivante :\n");
    }

    // Déclarer et initialiser les variables restant et representation_finale
    int restant = Math.Abs(representation_initiale);
    string representation_finale = "";

    // Pour une valeur de compteur_dexposants de la valeur de plus_gros_exposant à 0, exécuter le bloc de code suivant
    for (double compteur_dexposants = plus_gros_exposant_entier; compteur_dexposants >= 0; compteur_dexposants--)
    {
        // Déclarer et initialiser les variables nombre_a_convertir_en_chiffre et base_et_exposant
        int nombre_a_convertir_en_chiffre = 0;
        int base_et_exposant = (int)Math.Pow(base_de_lexponentielle, compteur_dexposants);

        // Si le restant modulo base_et_exposant est différent de 0
        if (restant % base_et_exposant != 0)
        {
            // Définir que nombre_a_convertir_en_chiffre est égal au résultat des étapes suivantes :
            // 1) Soustraire de restant le résidu de la division par base_et_exposant;
            // 2) Diviser le résultat précédent par base_et_exposant;
            // 3) Convertir en int le nouveau résultat.
            nombre_a_convertir_en_chiffre = (int)((restant - restant % base_et_exposant) / base_et_exposant);

            // Définir que restant est égal à restant moins le résultat de nombre_a_convertir_en_chiffre * base_et_exposant
            restant = restant - nombre_a_convertir_en_chiffre * base_et_exposant;
        }

        // Si le restant modulo base_et_exposant est égal à 0 et le restant est égal à 0
        else if (restant % base_et_exposant == 0 && restant == 0)
        {
            // Définir que nombre_a_convertir_en_chiffre est égal à 0
            nombre_a_convertir_en_chiffre = 0;
        }

        // Si le restant modulo base_et_exposant est égal à 0 et le restant est différent de 0
        else
        {
            // Définir que nombre_a_convertir_en_chiffre est égal au résultat de la division de restant
            // par base_et_exposant
            nombre_a_convertir_en_chiffre = (int)(restant / base_et_exposant);

            // Définir que le restant est égal à 0
            restant = 0;
        }

        // Afficher le résultat
        Console.WriteLine("Valeur du chiffre en position " + (compteur_dexposants + 1) + " -> " +
                          SYMBOLES_POUR_CONVERSION[nombre_a_convertir_en_chiffre] + " * " + base_de_lexponentielle + "^" + compteur_dexposants);

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

// Afficher un message, puis faire le choix de continuer ou pas
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