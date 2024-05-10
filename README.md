# BattleShips Web API

BattleShips is a simple implementation of the classic Battleship game as a Web API.

## Endpoints

### GET /battleships/player-board
- **Description**: Retrieves the current state of the player's board, including the placement of their ships.
- **Response**: Returns a JSON array representing the player's board.

### GET /battleships/computer-board
- **Description**: Retrieves the current state of the computer's board, hiding the placement of their ships.
- **Response**: Returns a JSON array representing the computer's board, with hidden ship locations.

### POST /battleships/fire-shot
- **Description**: Allows the player to fire a shot at the computer's board by providing coordinates.
- **Request Body**: JSON object containing the coordinates of the shot.
- **Response**: Provides feedback on whether the shot was a hit or a miss, and updates the game state accordingly.

### GET /battleships/re-player
- **Description**: Retrieves the current state of the player's board for replay purposes, showing all ship placements.
- **Response**: Returns a JSON array representing the player's board, including all ship locations.

## Technologies Used

- **.NET 7 Web API**: A framework for building HTTP-based services.
- **NUnit**: A unit testing framework for the .NET platform.
- **Microsoft.VisualStudio.TestTools.UnitTesting**: Another unit testing framework provided by Microsoft.
- **Git and GitHub**: Version control and collaborative development platform.

## How to Run Locally
To run the project locally, make sure you have .NET 7 installed. Then, follow these steps:

1. **Clone Repository**: Clone this repository to your local machine.
   ```bash
   git clone https://github.com/RandikaSilva/BattleshipsBackEndAPI.git
   
2. **Clean and Rebuild**: Clean and rebuild your project the necessary packages are getting installed if you are connected to the internet.
