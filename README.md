<p align="center">
    This project provides a solution for displaying statistics from the 2018 Men's and 2019 Women's FIFA World Cup.
</p>

<!-- ABOUT THE PROJECT -->
## 📌 About The Project

The project consists of three interconnected applications which display statistics from the 2018 Men's and 2019 Women's World Cup using a specific API: [Football API](https://worldcup-vua.nullbit.hr).

**Data Layer** is class library responsible for retrieving, parsing, and mapping data from the API, preparing it for use in both client applications.

**Windows Forms application** provides a user interface where users can select preferences, such as gender of the championship and language, pick a favorite national team and top players, and view rankings of players and matches. The application includes drag-and-drop functionality for managing favorite players and supports printing rankings as PDFs. 

**Windows Presentation Foundation application** offers a responsive interface that adapts to various screen sizes. It allows users to select and compare national teams, displaying detailed match results. The application also features an interactive visualization of team lineups, where players are positioned on a football field based on their roles.

Both applications rely on the shared Data Layer for data manipulation, enabling a consistent and efficient experience across both platforms.

## 🛠 Built With

### Languages & Frameworks
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-68217A?style=for-the-badge&logo=windows&logoColor=white)


