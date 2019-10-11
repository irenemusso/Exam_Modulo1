using exam1_IreneMusso.Entities;
using exam1_IreneMusso.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace exam1_IreneMusso.Procedures
{
    public class funzioniProdotti
    {
        private static void AggiungiPersonaARubricaInPosizione(List<Prodotti> elenco)
        {
            // Richiedo il codice e il nome
            Console.Write("CodiceAlfanumerico: ");
            var code = Console.ReadLine();
            Console.Write("NomeProdotto: ");
            var name = Console.ReadLine();

            //Creo oggetto PRodotto da inserire in Elenco
            Prodotti product = new Prodotti
            {
                CodiceAlfanumerico = code,
                NomeProdotto = name
            };

            //7) Aggiungo prodotto a elenco
            elenco.Add(product);

            
        }

        public static void InserisciNumeroArbitrarioProdottiInElenco()
        {
            // Richiedo il numero di prodotti da inserire
            Console.WriteLine("Quanti prodotti vuoi inserire (da 1 a 10)? ");
            int totalPersons = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 10);

            

            //Dimensionamento dell'elenco
            List<Prodotti> elenco = new List<Prodotti>();

            // Itero per il numero di prodotti richiesto
            for (int index = 0; index < totalPersons; index++)
            {
                //Richiamo una funzione a cui passo l'elenco
                //e l'indice corrente e questa mi aggiunge il prodotto
                AggiungiPersonaARubricaInPosizione(elenco);
            }

            //Itero l'elenco e stampo a video tutte le persone
            StampaElencoProdotti(elenco);

            foreach (Prodotti product in elenco)
            {
                SalvaProdottiInFile(product);
            }


            //Cerimonia finale
            ConsoleUtils.ConfermaUscita();
        }

        private static void SalvaProdottiInFile(Prodotti product)
        {
            //Assicuriamoci che esista la folder per il file di archivio
            var archiveFolder = FunzioniFileSystem.AssicuratiCheEsistaCartellaDiArchivio();
            //** Arrivo a questo punto e sono sicuro al 100% che la cartella dove
            //** sarà conservato il file database esiste: ne ottengo il percorso

            string datiDellaPersonaInFormatoStringa = ConvertiPersonaInStringa(product);

            //Aggiungi testo a file
            FunzioniFileSystem.AggiungiTestoAFileDatabase(datiDellaPersonaInFormatoStringa, archiveFolder);
        }


        private static string ConvertiPersonaInStringa(Prodotti person)
        {
            return $"{person.CodiceAlfanumerico},{person.NomeProdotto}";
        }






        public static void StampaElencoProdotti(List<Prodotti> ElencoProdotti)
        {
            Console.WriteLine("*** Visualizzazione contenuto ElencoProdotti***");
            for (var index = 0; index < ElencoProdotti.Count; index++)
            {
                Console.WriteLine($" => {ElencoProdotti[index].CodiceAlfanumerico}, {ElencoProdotti[index].NomeProdotto}");

            }
        }
    }
}
