# MeowZone
Celem projektu jest stworzenie internetowego forum dla miłośników kotów, gdzie użytkownicy mogą wymieniać się doświadczeniami, zadawać pytania i dzielić się wiedzą na temat opieki nad kotami, ich zdrowia, zachowania i innych aspektów związanych z posiadanymi pupilami.

# Opis plików i folderów

## Foldery

**MeowZone.UI** - znajdują się tutaj kontrolery, widoki, pliki statyczne i główny plik aplikacji </br>
Controllers - folder kontrolerów </br>
Views - folder widoków </br>
wwwroot - folder na pliki statyczne </br>
properties - folder na plik konfiguracyjny </br>

</br>


**MeowZone.Infrastructure** - znajduje się tutaj kod odpowiedzialny za baze danych. </br>
DbContext - folder na dbContext bazy </br>
Migrations - folder stworzony przez EF Core na migracje bazodanowe </br>
Repositories - folder na repozytoria odpowiedzialne za działania na obiektach w bazie danych. </br>

</br>

**MeowZone.Core** - znajdują się tutaj obiekty DTO, modele, interfejsy repozytoriów oraz serwisów jak i serwisy. </br>
Domain - folder na modele i interfejsy serwisów </br>
Domain/Entities - folder na modele </br>
Domain/IdentityEntities - folder na modele związane z użytkownikiem </br>
Domain/RepositoryContracts - folder na interfejsy repozytoriów</br>
DTO - folder na obiekty DTO </br>
Enums - folder na typy wyliczeniowe </br>
ServiceContracts - folder na interfejsy serwisów </br>
Services - folde na serwisy </br>

</br>






