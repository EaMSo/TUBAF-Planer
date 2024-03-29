# TUBAF-Planer
Automatisch generierter Modul-Wochenplan für die Technische Universität Bergakademie Freiberg
## Generelle Funktionen der Wochenplananwendung
- liest die benötigten Daten aus einer Datenbank aus ✔️
- Generiert einen personalisierten Wochenplan für jeden Studenten basierend auf seinem Studienfach und Semester (welches er vorher angibt aber nicht muss (Preset)) ❌
-> Berücksichtigt die Vorlesungszeiten, Pausen und individuellen Präferenzen ✔️
- ~bei nur Angabe des Studienfachs kann~ der User kann sich frei aus allen Modulen einen Wochenplan erstellen ✔️
- wenn es zeitliche Überlappungen bei der Zusammenstellung gibt wird der User gewarnt ✔️
- Einträge in dem Wochenplan können individualisiert werden ✔️
- Fertiger Wochenplan kann ~als PDF abgespeichert werden~ mit dem snipping Tool genippt werden oder innerhalb des Programms angekuckt werden ~(oder in einer Kalenderfunktion angesehen werden) --optional~ 🟨
## MAUI
- Wir haben uns entschieden, das Projekt mit MAUI umzusetzen, um etwas über UI Design zu lernen
- Zusätzlich bietet MAUI die Möglichkeit, die Anwendung auf Windows, Mac, Android und IOS zu installieren
- Hinweis: Das Projekt zu kompilieren erfordert(auf Windows) den Entwicklermodus zu aktivieren
## Weiteres Vorgehen
- wärend der Entwicklung des Programms werden auch noch weitere Features realisiert (wenn es sich anbietet) ✔️
## Porten?
- wenn die Software auf einem Computer funktioniert wäre es vorstellbar sie auch auf Android und IOS zu Porten (und eventuell auch auf eine Website) ❌
- bis jetzt wurde das Programm nur auf Windows getestet
 
## Schwierigkeiten beim Testen
   Wie sich herausgestellt hat ist XUnit nicht instande bestimmte Dinge in einem MAUI Projekt sinnvoll zu Testen siehe [hier](https://learn.microsoft.com/en-us/answers/questions/1190946/cant-use-microsoft-maui-storage-preferences-in-uni).
   Wir haben probiert die Lösung, die dort beschrieben wird und viele andere zu Implementieren, aber es funktionierte nicht. Der Fehler beim Testen kann reproduziert werden, wenn der auskommentierte Code in Unittest1 beim Testen benutzt wird. 
   Dazu einfach entkommentieren, speichern und dann "dotnet test" in die Kommandozeile eingeben. Wenn eine einfache Lösung für diesen Fehler existiert würde mich sehr interesieren wie diese geht.   ~Emil Sommer

## Zusätzlich benutzte Pakete
- [Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite) (um SQLite als Datenbank nutzen zu können)
- [Community Toolkit MVVM](https://www.nuget.org/packages/CommunityToolkit.Mvvm) (leichtere Benutzbarkeit von MAUI)

## Wiki
- Die Benutzung der Programms wird im Wiki erklärt!!!

# UML Diagramm erster Programmentwurf
![UML Diagramm Entwurf1](http://www.plantuml.com/plantuml/png/fP11IyGm48Nl-HMX9nLwy2eYknGyxUAglo0c8orE4ibC5iJrlnir8McHNhQtcNvvxytR4Al0qQBGg8Zay-Dk3pnwG-9JoFHfxuX3rEp3nQNu4fdRUnCHCZEiCRk9E7DRO_vsYVgPdy3w8vHLGRQ8XrUSzCY3Zu60Miq3AlSI9pGGYla8-ktX207LUnPPzwbYzn5n5lASZBBg3f7Ostb50HHdSr5BbbTzdtkIDp8c8P6dpYhtqVt-xwwxfil4QUzOJOv4ixqzzSjx_bTQGbKY4Ms_9L1zi4QrDyl-T9SJp_VbskmjDk1CjFWD)
# UML Diagramm zweiter Programmentwurf
![UML Diagramm Entwurf2](http://www.plantuml.com/plantuml/png/fPJVQzim4CVV_LU8x2NPrj2tGWYXIuB7e6NTch37SBKljPXa6TrfOup-xvEbiVZ7t9hK3p7exZxVK-vxlYO6oquhiTklFwI7EmKbsiD60T5XA-7HWZxignmOyoGfGIDLa64hM_nEX7-okaQarfICPHuEu_DkAwbIyEi-Ap1t2gUpK-YJJxR7cdWqLkm9xT_eKn9U9yLRusirSc5oQi2ZwlsNczjUA0XyHDu2WszBr-y78A-_43UIU1cGgvWV9TlK4Ey2Asigj2oHp57N2JGCI9rI8GThlV-qrauOtTZ64HiTih1BtLW4ncR6TFR25V7p3xGAgagMZprSWTdtHdmQswLMfxxl1sFKiCns_SrA3lZ-UDPtm4MhoVZxr3FS3ecfPRTzAJcUBfTYkdl_9aslhYulPo4WV2I8hbPDEtvrPIY9ab6ewUVvFmzVN8XMeEd1UMi82p7HKChAAM0aaGF3v1neVnwUdDKp867YAPq5xbZHKnrXrw6U_7ndNkFjCoADDLpK-6HqFtrkNpiPEOiHhC5_S7pbAwzqsWW_2kdbBMHCugVamc_BPFHTNwCnBEARRspS_BHbqJTv-5exVoeuhjY09y_W9DU-pccL_040)
# UML Diagramm dritter Programmentwurf
![UML Diagramm Entwurf3](http://www.plantuml.com/plantuml/png/hLHTJzim57tlhx3OInaBuWq9eOhIgjCa41qjs-Dqazoj5lx8x6kgxkE_BuvXYOCPGImFZNhFpJt7FZu-imI6d1GZ1H9j1GMozStvTF5bAK2XOJz7h7uA0TOoNyeT5oMQJnotbxf44HhQvogtQEuW5pZJGc11NAlJkjE92MjUEA1_vYnf6TedhFlF3cTReIzW-U8F_JB_TXzSQ7WOCTvlotDkAm6xW7I1cK4Wx6gEFaE1VPIn5f-MzsHh_Q3_WblgZdYF2WqGUfdtzT-ZvjLQsCoGI1jTsev3mSRLnulB66f7qnm85aPB_yx1rl9Ec5TmlpcXFr36KnkyVngoB8iBbWnNtrYXdR7ezIPXSaOvcuIsYBSbx9AOtozdq2H1exLC0aq2aWYgCgwFdIfPYGOLMnfTeI6ETl-P9H-i-0_ibUQmcsdXfEhLryt20xIgu17C9LxhxQfH_BGL2oU4R4wHTovXSjoGjZZk3YSstPrM4SKsrf0EIQfZ3NaF2f9k5F_kS6culCLT7myPUpGsVMBnwWwDWAhoXlTKJfMc3PhGzy5EQGKIlGVZi7assebwNtAjnTDyy_FFXbE2nyVkV0cqYTI6ttfAxsPUeoKRtSlrRb2edfwoyVhTcyNY-FZeQBy1c4SywMJIuJsuTghv9506ekx5VvYyxBECHKtTU-OmClo4xKbGl78222qhWM3ljGIF3FCinGQBMyjqgDfNayJPy0pEOZzJBKjQfUTu-m-IpXLyuiUF1kk9vwQvHmCzoh9Va-U63TZE0PB-r_hQ2DM-S4Lee23BjfmsTRpsXYxyLHnFazJYEn4zR6CP3b79lch3dCyaXKmEEQmldtc6gdHI_040)
