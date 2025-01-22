//ecrand de bienvenue

void EcranBienvenue()
{
    Console.Clear();
    Console.WriteLine("\tLaboratoire_01!");
    Console.WriteLine("\tBenvenue dans le magasin!");
    Console.WriteLine("\tFichier de facturation");
    Console.WriteLine("\tdu magasin d'articles électronique");
    Console.WriteLine("\tVivre à la moderne");
}

//Fonction pour retourner le choix
char menu()
{
    Console.WriteLine("Voulez-vous continuer (O/N)?: ");
    char choix;
    choix = char.Parse(Console.ReadLine());
    return choix;
}

//Fonction qui calcule le cout avant le rabais
int CalculerCoutAvantRabais(int nombreArticle, int coutUnite)
{
    return nombreArticle * coutUnite;
}

//Fonction qui calcule le cout apres le rabais

float CalculerCoutApresRabais(float montantAchat, float pourcentageRabais)
{
    return montantAchat - (montantAchat * pourcentageRabais);
}

//Calcul de la TPS

float CalculerTPS(float montantApresRabais, float tauxTPS)
{
    return montantApresRabais * tauxTPS;  
}

//Calcul de la TVQ

float CalculerTVQ(float montantApresRabais, float tauxTVQ)
{
    return montantApresRabais * tauxTVQ;
}
//Calculer le total 

float CalculerTotal(float montantApresRabais, float montantTVQ, float montantTPS)
{
    return (montantApresRabais + montantTVQ + montantTPS);
}

//Calculer le pourcentage de reduction

float CalculerPourcentageReduction(char categorie, int nombreArticle, int coutUnite)
{
    int valeur;
    float pourcentageRabais;

    switch (categorie)
    {
        case 'R':
        case 'r':
            valeur = CalculerCoutAvantRabais(nombreArticle, coutUnite);
            if (valeur <= 250 && valeur < 500)

                pourcentageRabais = 0.25f; //25% reduc
            else if (valeur >= 500)
                pourcentageRabais = 0.30f; //30% reduc
            else
                pourcentageRabais = 0.050f; //5% reduc
            break;
        case 'T':
        case 't':
            valeur = CalculerCoutAvantRabais(nombreArticle, coutUnite);
            if (valeur < 500)
                pourcentageRabais = 0.4f; //40% reduc
            else
                pourcentageRabais = 0.5f; //50% reduc
            break;
        default:
            pourcentageRabais = 0.2f; //20%
            break;
    }
    return pourcentageRabais;
}

//Fonction qui affiche la facture sur la console

void AfficherFacture(string nom,  string prenom, char categorie, float pourcentageRabais, float sommeAvantRabais, float sommeApresRabais,
    float sommeTPS, float sommeTVQ, float SommeTotal, int nombreArticle)
{
    //Affichage Console

    Console.WriteLine(String.Format("{0}:{1}", "NOM" , nom)); // Console.Writeline("NOM", + nom) //
    Console.WriteLine(String.Format("{0}:{1}", "PRENOM", prenom));
    Console.WriteLine(String.Format("{0}:{1}", "CATEGORIE", categorie));
    Console.WriteLine(String.Format("{0}:{1}", "NOMBRE ARTICLE", nombreArticle));
    Console.WriteLine(String.Format("{0}:{1}", "POURCENTAGE RABAIS", pourcentageRabais));
    Console.WriteLine(String.Format("{0}:{1}", "SOMME AVANT LE RABAIS", sommeAvantRabais));
    Console.WriteLine(String.Format("{0}:{1}", "SOMME APRES LE RABAIS", sommeApresRabais));
    Console.WriteLine(String.Format("{0}:{1}", "TPS", sommeTPS));
    Console.WriteLine(String.Format("{0}:{1}", "TVQ", sommeTVQ));
    Console.WriteLine(String.Format("{0}:{1}", "TOTAL", SommeTotal));

    //Sauvegarde dans le fichier texte

    StreamWriter fichier = new StreamWriter("Facture.txt" , true);//Ouvre le fichier en ecriture si le fichier existe,
                                                                  //ou alors crée le fichier et le passe en mode écriture
                                                                  //si le fichier n'existe pas
    fichier.WriteLine(String.Format("{0}:{1}", "NOM", nom)); // Console.Writeline("NOM", + nom) //
    fichier.WriteLine(String.Format("{0}:{1}", "PRENOM", prenom));
    fichier.WriteLine(String.Format("{0}:{1}", "CATEGORIE", categorie));
    fichier.WriteLine(String.Format("{0}:{1}", "NOMBRE ARTICLE", nombreArticle));
    fichier.WriteLine(String.Format("{0}:{1}", "POURCENTAGE RABAIS", pourcentageRabais));
    fichier.WriteLine(String.Format("{0}:{1}", "SOMME AVANT LE RABAIS", sommeAvantRabais));
    fichier.WriteLine(String.Format("{0}:{1}", "SOMME APRES LE RABAIS", sommeApresRabais));
    fichier.WriteLine(String.Format("{0}:{1}", "TPS", sommeTPS));
    fichier.WriteLine(String.Format("{0}:{1}", "TVQ", sommeTVQ));
    fichier.WriteLine(String.Format("{0}:{1}", "TOTAL", SommeTotal));

    fichier.Close();//Fermeture du fichier

}




//Debut du programme principal

int nombrearticle;
float sommeApresRabais, sommeTVQ, sommeTPS, sommeAvantRabais, ValeurReduite, sommeTotal;
string nom, prenom;

char categorie;
const int CoutUnite = 20;
const float TauxTPS = 0.05f;
const float TauxTVQ = 0.09975f;

char choix = 'O';

do
{
    EcranBienvenue();

    Console.Write("Veuillez entrer votre nom: ");
    nom = Console.ReadLine();

    Console.Write("Veuillez entrer votre prenom: ");
    prenom = Console.ReadLine();

    Console.Write("Veuillez entrer le nombre d'articles: ");
    nombrearticle = int.Parse(Console.ReadLine());

    Console.Write("Veuillez entrer votre categorie (entrer une lettre R ou T ou C) : ");
    categorie = char.Parse(Console.ReadLine());

    //Operation de calcul

    //1. Calculer le cout avant le rabais
    sommeAvantRabais = CalculerCoutAvantRabais(nombrearticle, CoutUnite);
    //2. Calcule le pourcentage de reduction
    ValeurReduite = CalculerPourcentageReduction(categorie, nombrearticle, CoutUnite);
    //3. Calcul du cout apres le rabais
    sommeApresRabais = CalculerCoutApresRabais(sommeAvantRabais, ValeurReduite);
    //4. Calcul la TPS
    sommeTPS = CalculerTPS(sommeAvantRabais, TauxTPS);
    //5. Calcul de la TVQ
    sommeTVQ = CalculerTVQ(sommeApresRabais, TauxTVQ);
    //6. Calcul Total
    sommeTotal = CalculerTotal(sommeApresRabais, sommeTPS, sommeTVQ);

    //Appel de la fonction pour afficher la facture a lecran

    AfficherFacture(nom, prenom, categorie, ValeurReduite, sommeAvantRabais, sommeApresRabais, sommeTPS, sommeTVQ, sommeTotal, nombrearticle);


    // Fait appel à la fonction menu pour récuperer le choix
    choix = menu();

} while (choix != 'N');

Console.WriteLine("Merci pour votre visite!");
Console.ReadKey();
