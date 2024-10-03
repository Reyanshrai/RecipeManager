# Cook Recipe Management System

This project is a **Windows Forms Application** built using .NET for managing and organizing recipes. The system provides an easy-to-use interface where users can create, view, delete, and print recipes. The application stores all recipes in a database and displays them dynamically within the user interface.

## Features

- **Dashboard**: A simple user-friendly dashboard with two primary options:
  - **Create a Recipe**: Allows users to add new recipes with details and an image.
  - **View All Recipes**: Lists all stored recipes from the database with dynamic buttons for detailed view, delete, and print options.
  
- **Create Recipe Form**: This form allows users to input the following details for a new recipe:
  - Recipe Name
  - Ingredients
  - Cooking Instructions
  - Cooking Time
  - Servings
  - Category (e.g., Breakfast, Lunch, Dinner, Dessert, etc.)
  - Recipe Image Upload

- **View All Recipes**: Displays all recipes in a list format, dynamically generating buttons to:
  - **View Details**: Opens a popup with the recipe's full details and image.
  - **Delete Recipe**: Removes the recipe from the database.
  - **Print Recipe**: Prints the recipe using the system's printing capabilities.

## Technology Stack

- **.NET Framework**: The application is built using .NET, specifically a Windows Forms Application.
- **Database**: Recipes are stored and managed using SQLite for lightweight and efficient data storage.
- **Image Handling**: Users can upload an image for each recipe, which is stored and retrieved when viewing recipes.
- **Print Functionality**: The application supports printing the recipe directly from the interface.

  ## Screenshots
  - **Main Dashboard** :- <br><img width="628" alt="image" src="https://github.com/user-attachments/assets/01cf2df3-5d4c-4555-acc5-0366fdf27fc0"> <br>
  - **Create Recipe** :- <br><img width="629" alt="image" src="https://github.com/user-attachments/assets/66ddc62b-b41b-44a0-aea6-09c417d74637"> <br>
  - **View Recipe** :- <br><img width="747" alt="image" src="https://github.com/user-attachments/assets/c93e1365-8ff7-4d13-827b-a50845d1b352">




## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/Cook-Recipe-Management.git
