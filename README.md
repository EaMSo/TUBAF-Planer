# TUBAF-Planer
Automatisch Generierter Modul-Wochenplan für die Technische Universität Bergakademie Freiberg
## Generelle Funktionen der Wochenplananwendung
- liest die benötigten Daten aus einer Datenbank aus
- Generiert einen personalisierten Wochenplan für jeden Studenten basierend auf seinem Studienfach und Semester (welches er vorher angibt aber nicht muss (Preset))
-> Berücksichtigt die Vorlesungszeiten, Pausen und individuellen Präferenzen 
- bei nur Angabe des Studienfachs kann der User sich frei aus allen Modulen einen Wochenplan erstellen
- wenn es zeitliche Überlappungen bei der Zusammenstellung gibt wird der User gewarnt
- Einträge in dem Wochenplan können individualisiert werden
- Fertiger Wochenplan kann als PDF abgespeichert werden oder innerhalb des Programms... (oder in einer Kalenderfunktion angesehen werden) --optional
## Weiteres Vorgehen
- wärend der Entwicklung des Programms werden auch noch weitere Features realisiert, wenn sie sich anbieten
## Porten?
- wenn die Software auf einem Computer funktioniert wäre es vorstellbar sie auch auf Android und IOS zu Porten (und eventuell auch auf eine Website)


## Zusätzliche benutzte Pakete
- [Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite)(um SQLite als Datenbank nutzen zu können)
