# Database2Project
## Systeemspecificaties 
* CPU: AMD Ryzen 9 3900X
* GPU: AMD Radeon RX 6800 XT
* RAM: 48GB 1066.4 MHz DDR4
* OS: Windows 11 Pro 64-bit

# Bevindingen
Hieronder staan de bevinding getoont voor de verschillende CRUD operaties bij verschillende databases/gegevenstoegangsservices. De resultaten hiervan zijn weergegeven in miliseconden. Hierbij is er voor gekozen om MongaDB in de cloud te gebruiken, dit is gedaan omdat ik benieuwed was naar de impact hiervan op de sneleheden. Hierbij is het intressant om te zien dat het verschil in snelheden vrij klein is in tegenstelling tot mijn verwachtingen. Ik had zelf verwacht dat voor de Create, Update en Delete statements de delay van het versturen van de opdracht veel erger vertraagt zouden zijn dan uit de test blijkt (behalve bij 1000 regels). Verder kwam het overeen met wat ik verwachte, Entity framework is snel met het ophalen van data en ado.net is snel met het wegschrijven van data. Wel viel het op dat na het uitvoerig testen met meerdere duizenden regels dat de database uiteindlijk slomer werdt.

## SELECT
 ### Ado.Net :
     Miliseconds for 1 row:       7
     Miliseconds for 10 row:      5
     Miliseconds for 100 row:     5
     Miliseconds for 1000 row:    11

 ### Entity framework :
     Miliseconds for 1 row:       0
     Miliseconds for 10 row:      0
     Miliseconds for 100 row:     0
     Miliseconds for 1000 row:    3

 ### MongoDB :
     Miliseconds for 1 row:       24
     Miliseconds for 10 row:      22
     Miliseconds for 100 row:     47
     Miliseconds for 1000 row:    116


## CREATE :
 ### Ado.Net :
     Miliseconds for 1 row:       41
     Miliseconds for 10 row:      54
     Miliseconds for 100 row:     548
     Miliseconds for 1000 row:    5509

 ### Entity framework :
     Miliseconds for 1 row:       488
     Miliseconds for 10 row:      369
     Miliseconds for 100 row:     379
     Miliseconds for 1000 row:    465

 ### MongoDB :
     Miliseconds for 1 row:       80
     Miliseconds for 10 row:      24
     Miliseconds for 100 row:     954
     Miliseconds for 1000 row:    1037


## UPDATE :
 ### Ado.Net :
     Miliseconds for 1 row:       250
     Miliseconds for 10 row:      134
     Miliseconds for 100 row:     1251
     Miliseconds for 1000 row:    12412

 ### Entity framework :
     Miliseconds for 1 row:       352
     Miliseconds for 10 row:      352
     Miliseconds for 100 row:     367
     Miliseconds for 1000 row:    462

 ### MongoDB :
     Miliseconds for 1 row:       189
     Miliseconds for 10 row:      96
     Miliseconds for 100 row:     10936
     Miliseconds for 1000 row:    9480


## DELETE :

 ### Ado.Net :
     Miliseconds for 1 row:       135
     Miliseconds for 10 row:      116
     Miliseconds for 100 row:     1088
     Miliseconds for 1000 row:    11270

 ### Entity framework :
     Miliseconds for 1 row:       802
     Miliseconds for 10 row:      486
     Miliseconds for 100 row:     1632
     Miliseconds for 1000 row:    11837

 ### MongoDB :
     Miliseconds for 1 row:       660
     Miliseconds for 10 row:      1111
     Miliseconds for 100 row:     5759
     Miliseconds for 1000 row:    52670
