# QuizMaster

## Purpose of the Program

The purpose of the QuizMaster program is to provide an interactive quiz game for the user. The quiz consists of multiple-choice questions related to football, specifically focusing on Real Madrid and Cristiano Ronaldo. Users must select the correct answer within a given time limit for each question. The program will then display the user's final score at the end of the quiz.

## Instructions on How to Run the Program

### Prerequisites

- Ensure you have .NET SDK installed on your machine. You can download it from [Microsoft's official website](https://dotnet.microsoft.com/download).

### Running the Program

1. **Clone or Download the Repository**
   - Clone the repository using `git clone <https://github.com/jafarramadan/QuizMaster-Challenge.git>`, or download the ZIP file and extract it.

2. **Navigate to the Project Directory**
   - Open a terminal or command prompt.
   - Navigate to the directory where the program is located.

3. **Compile the Program**
   - Run the following command to compile the program:
     ```bash
     dotnet build
     ```

4. **Run the Program**
   - After a successful build, run the program using:
     ```bash
     dotnet run
     ```

5. **Play the Quiz**
   - Follow the on-screen instructions to answer each question by typing the corresponding number (1, 2, 3, or 4).
   - Answer each question within the specified time limit (30 seconds).
   - Your final score will be displayed at the end of the quiz.

## Additional Information

- **Time Limit:** Each question must be answered within 30 seconds. If you fail to answer within the time limit, you will receive a message indicating that time is up, and the program will proceed to the next question.
- **Answer Validation:** If an invalid answer (other than 1, 2, 3, or 4) is entered, you will be prompted to enter a valid answer, and the same question will be repeated.
- **Scoring:** Correct answers are counted towards your final score, which will be displayed at the end of the quiz.

Enjoy the quiz and test your knowledge about Real Madrid and Cristiano Ronaldo!
