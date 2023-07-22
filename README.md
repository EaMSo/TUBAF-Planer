# TUBAF-Planer
Automatisch generierter Modul-Wochenplan für die Technische Universität Bergakademie Freiberg
## Generelle Funktionen der Wochenplananwendung
- liest die benötigten Daten aus einer Datenbank aus
- Generiert einen personalisierten Wochenplan für jeden Studenten basierend auf seinem Studienfach und Semester (welches er vorher angibt aber nicht muss (Preset))
-> Berücksichtigt die Vorlesungszeiten, Pausen und individuellen Präferenzen 
- bei nur Angabe des Studienfachs kann der User sich frei aus allen Modulen einen Wochenplan erstellen
- wenn es zeitliche Überlappungen bei der Zusammenstellung gibt wird der User gewarnt
- Einträge in dem Wochenplan können individualisiert werden
- Fertiger Wochenplan kann als PDF abgespeichert werden oder innerhalb des Programms... (oder in einer Kalenderfunktion angesehen werden) --optional
## Weiteres Vorgehen
- wärend der Entwicklung des Programms werden auch noch weitere Features realisiert (wenn es sich anbietet)
## Porten?
- wenn die Software auf einem Computer funktioniert wäre es vorstellbar sie auch auf Android und IOS zu Porten (und eventuell auch auf eine Website)


## Zusätzlich benutzte Pakete
- [Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite) (um SQLite als Datenbank nutzen zu können)
- [Community Toolkit MVVM](https://www.nuget.org/packages/CommunityToolkit.Mvvm) (leichtere Benutzbarkeit von MAUI)



# UML Diagramm erster Programmentwurf
![UML Diagramm Entwurf](http://www.plantuml.com/plantuml/png/fP11IyGm48Nl-HMX9nLwy2eYknGyxUAglo0c8orE4ibC5iJrlnir8McHNhQtcNvvxytR4Al0qQBGg8Zay-Dk3pnwG-9JoFHfxuX3rEp3nQNu4fdRUnCHCZEiCRk9E7DRO_vsYVgPdy3w8vHLGRQ8XrUSzCY3Zu60Miq3AlSI9pGGYla8-ktX207LUnPPzwbYzn5n5lASZBBg3f7Ostb50HHdSr5BbbTzdtkIDp8c8P6dpYhtqVt-xwwxfil4QUzOJOv4ixqzzSjx_bTQGbKY4Ms_9L1zi4QrDyl-T9SJp_VbskmjDk1CjFWD)
