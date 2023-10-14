# JEM-id-API

Lokaal draaien van de api:
* Stap 1: Download de code vanaf GitHub. Onder de groene knop "Code" -> "Download ZIP"
* Stap 2: Maak lokaal een lege SQL database aan.
* Stap 3: Kopieer de connectiestring naar de database en zet deze in het appsettings.Development.json bestand (Dit is voor lokaal draaien, als het niet lokaal is, zet de connectie string dan in appsettings.json)
* Stap 4: Open de code in Visual Studio
* Stap 5: Via de "Package Manager Console" kan de database geupdate worden. Typ in: 'Update-Database' (zonder de quotes) en druk op enter.
* De database wordt nu geupdate en dit is ook in de console te zien.
* Stap 6: Start de applicatie, een venster in de browser opent.

Voorbeeld van een artikel in de database:
{
    "code": "82a5ae05-f143",
    "name": "Zonnebloem",
    "potSize": 10.2,
    "plantHeight": 25.5,
    "color": 0,
    "productGroup": 1
}

Op de swagger pagina zijn er verschillende endpoints zichtbaar:
/GetAll -> Dit is een GET om alle artikelen op te halen.

/GetByFilter -> Dit is een GET om artikelen op te halen met de mogelijkheid om te filteren.
* Alle velden zijn optioneel, ze mogen ook leeg blijven.
* name -> zoekt in de naam van het artikel, dit is niet hoofdletter gevoelig.
* Voorbeeld: Zonnebloem kan gevonden worden door op "zon" te filteren.
* fromPotSize -> werkt samen met toPotSize en moeten in combinatie meegeven worden.
* Voorbeeld: Zonnebloem kan gevonden worden door fromPotSize 10.1 en toPotSize 14 te filteren.
* color -> zoekt in de kleur van de artikelen.
* Voorbeeld: Zonnebloem kan gevonden worden door color 0 te filteren.
* productGroup -> zoekt in de product groep van de artikelen.
* Voorbeeld: Zonnebloem kan gevonden worden door productGroup 1 te filteren.

/Create -> Dit is een POST om een nieuw artikel aan te maken.
* Alle velden zijn verplicht, behalve color.
* Voorbeeld om een nieuw artikel aan te maken met komma getallen voor PotSize en PlantHeight.
* Name: "Nieuw Artikel"
* PotSize: 15,5
* PlantHeight: 25,3
* Color: Getal naar keuze uit de lijst of leeg. In de ColorEnum is te zien welk getal bij een bepaalde kleur hoort.
* ProductGroup: Getal naar keuze uit de lijst. In de ProductGroupsEnum is te zien welk getal bij een bepaalde groep hoort.

/Update -> Dit is een PUT om een bestaand artikel te wijzigen.
* Alle velden zijn verplicht, behalve color.
* Voorbeeld om een bestaand artikel te updaten met komma getallen voor PotSize en PlantHeight.
* Code: Artikel code van een bestaand artikel. Code kan opgehaald worden met de /GetAll of /GetByFilter.
* Name: "Gewijzigd Artikel"
* PotSize: 10,9
* PlantHeight: 25,3
* Color: Getal naar keuze uit de lijst of leeg. In de ColorEnum is te zien welk getal bij een bepaalde kleur hoort.
* ProductGroup: Getal naar keuze uit de lijst. In de ProductGroupsEnum is te zien welk getal bij een bepaalde groep hoort.

/Delete -> Dit is een DELETE om een bestaand artikel te verwijderen.
* Vul de code in van een bestaand artikel. Code kan opgehaald worden met de /GetAll of /GetByFilter.

Keuzes:
De waardes van de enum stuur ik als getal naar de database. Dit doe ik omdat het voor kan komen dat de naam wijzigt van een waarde in de enum. Op het moment dat het dan als string in de database staat, heb je een probleem. Ook zet ik er specifiek = 0 of een ander getal achter, zo kan de volgorde wijzigen zonder dat het programma omvalt en ineens andere kleuren of productgroepen gaat tonen bij bestaande artikelen.

Voor de productgroepen twijfelde ik nog om dit ook een tabel in de database te maken en dit te linken met een foreign key. Voor het geval dat productgroepen uitgebreid moeten worden met bepaalde informatie. Dit heb ik voor nu niet gedaan om de opdracht niet te groot te maken, zoals aangegeven.

Ik heb Controller, Service, Repository pattern gebruikt, dit omdat de logica dan gescheiden is en verdeeld over de lagen. Elke laag heeft zijn eigen taak wat gedaan moet worden. Ook blijft het zo overzichtelijk en is het duidelijk in welke laag een bepaalde actie/logica gedaan wordt.