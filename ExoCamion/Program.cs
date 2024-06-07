using System;

class Camion
{
    public string NumeroPlaque;
    public string Marque;
    public int AnneeFabrication;
}

class CamionList
{
    private Camion[] camions;
    private int count;

    public CamionList(int size)
    {
        camions = new Camion[size];
        count = 0;
    }

    public void AddCamion(Camion camion)
    {
        if (count < camions.Length)
        {
            camions[count] = camion;
            count++;
        }
        
    }

    public void AfficherCamions()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Plaque: " + camions[i].NumeroPlaque + ", Marque: " + camions[i].Marque + ", Année: " + camions[i].AnneeFabrication);
        }
    }

    public void TrierParAnneeDecroissante()
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (camions[j].AnneeFabrication < camions[j + 1].AnneeFabrication)
                {
                    
                    (camions[j], camions[j + 1]) = (camions[j + 1], camions[j]);
                }
            }
        }
    }

    public void FiltrerParMarque(string marque)
    {
        for (int i = 0; i < count; i++)
        {
            if (camions[i].Marque.Equals(marque, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Plaque: " + camions[i].NumeroPlaque + ", Marque: " + camions[i].Marque + ", Année: " + camions[i].AnneeFabrication);
            }
        }
    }

    public bool CamionExiste(string numeroPlaque)
    {
        for (int i = 0; i < count; i++)
        {
            if (camions[i].NumeroPlaque == numeroPlaque)
            {
                return true;
            }
        }
        return false;
    }
}

internal class Program
{
    public void Main()
    {
        Console.WriteLine("Nombre de camions à encoder: ");
        int nbCamions;
        while (!int.TryParse(Console.ReadLine(), out nbCamions) || nbCamions <= 0)
        {
            Console.WriteLine("Veuillez entrer un nombre valide de camions.");
        }

        var camionList = new CamionList(nbCamions);

        for (var i = 0; i < nbCamions; i++)
        {
            var camion = new Camion();

            while (true)
            {
                Console.WriteLine("Donnez le numéro de plaque pour le camion " + (i + 1) + ":");
                var plaque = Console.ReadLine();

                if (!camionList.CamionExiste(plaque))
                {
                    camion.NumeroPlaque = plaque;
                    break;
                }
                else
                {
                    Console.WriteLine("Erreur : Ce numéro de plaque existe déjà. Veuillez entrer une nouvelle plaque.");
                }
            }

            Console.WriteLine("Entrez la marque du camion " + (i + 1) + ":");
            camion.Marque = Console.ReadLine();

            Console.WriteLine("Entrez l'année de fabrication du camion " + (i + 1) + ":");
            int annee;
            while (!int.TryParse(Console.ReadLine(), out annee) || annee <= 0)
            {
                Console.WriteLine("Veuillez entrer une année valide.");
            }
            camion.AnneeFabrication = annee;

            camionList.AddCamion(camion);
        }

        camionList.TrierParAnneeDecroissante();

        Console.WriteLine("Numéros de plaque des camions après le tri par année de fabrication décroissante:");
        camionList.AfficherCamions();

        Console.WriteLine("Entrez la marque pour filtrer les camions:");
        var marqueAFiltrer = Console.ReadLine();
        Console.WriteLine("Camions de la marque " + marqueAFiltrer + ":");
        camionList.FiltrerParMarque(marqueAFiltrer);
    }

    static void Main(string[] args)
    {
        var program = new Program();
        program.Main();
    }
}
