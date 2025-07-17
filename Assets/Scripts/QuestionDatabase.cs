using System.Collections.Generic;

[System.Serializable]
public class Question
{
    public string topic;
    public string questionText;
    public string[] options;
    public int correctAnswerIndex;
}

public class QuestionDatabase
{
    public List<Question> questions;

    public QuestionDatabase()
    {
        questions = new List<Question>();

        // DAA questions
        questions.Add(new Question
        {
            topic = "DAA",
            questionText = "Which of the following is not a stable sorting algorithm?",
            options = new string[] { "Bubble Sort", "Merge Sort", "Quick Sort", "Insertion Sort" },
            correctAnswerIndex = 2
        });
        questions.Add(new Question
        {
            topic = "DAA",
            questionText = "What is the time complexity of Binary Search in a sorted array?",
            options = new string[] { "O(1)", "O(log n)", "O(n)", "O(n^2)" },
            correctAnswerIndex = 1
        });
        questions.Add(new Question
        {
            topic = "DAA",
            questionText = "Which algorithm is used for finding the shortest path in a graph?",
            options = new string[] { "Kruskal's Algorithm", "Dijkstra's Algorithm", "Prim's Algorithm", "Bellman-Ford Algorithm" },
            correctAnswerIndex = 1
        });
        questions.Add(new Question
        {
            topic = "DAA",
            questionText = "In which type of problem does the divide-and-conquer strategy work best?",
            options = new string[] { "Greedy Problem", "Dynamic Programming Problem", "Sorting Problem", "Graph Problem" },
            correctAnswerIndex = 2
        });
        // Additional DAA questions
        questions.Add(new Question
        {
            topic = "DAA",
            questionText = "What is the average-case time complexity of Quick Sort?",
            options = new string[] { "O(n log n)", "O(n^2)", "O(n)", "O(log n)" },
            correctAnswerIndex = 0
        });
        questions.Add(new Question
        {
            topic = "DAA",
            questionText = "In the context of the Knapsack problem, what is the difference between the 0/1 Knapsack and Fractional Knapsack problem?",
            options = new string[] { "Fractional Knapsack allows splitting items", "0/1 Knapsack allows splitting items", "Fractional Knapsack has higher time complexity", "0/1 Knapsack is solved using greedy approach" },
            correctAnswerIndex = 0
        });
        questions.Add(new Question
        {
            topic = "DAA",
            questionText = "Which algorithm uses a technique called 'Dynamic Programming' to solve optimization problems?",
            options = new string[] { "Dijkstra's Algorithm", "Bellman-Ford Algorithm", "Floyd-Warshall Algorithm", "Prim's Algorithm" },
            correctAnswerIndex = 2
        });
        questions.Add(new Question
        {
            topic = "DAA",
            questionText = "What is the time complexity of the worst-case scenario in the Quick Sort algorithm?",
            options = new string[] { "O(n log n)", "O(n^2)", "O(n)", "O(log n)" },
            correctAnswerIndex = 1
        });

        // DBMS questions
        questions.Add(new Question
        {
            topic = "DBMS",
            questionText = "In SQL, which command is used to remove a table from the database?",
            options = new string[] { "DROP", "DELETE", "TRUNCATE", "REMOVE" },
            correctAnswerIndex = 0
        });
        questions.Add(new Question
        {
            topic = "DBMS",
            questionText = "Which of the following is a type of database relationship?",
            options = new string[] { "One-to-One", "Many-to-Many", "One-to-Many", "All of the above" },
            correctAnswerIndex = 3
        });
        questions.Add(new Question
        {
            topic = "DBMS",
            questionText = "What is a primary key in a database?",
            options = new string[] { "A unique identifier for a record", "A field used to link tables", "A field that can have duplicate values", "A key for encryption" },
            correctAnswerIndex = 0
        });
        questions.Add(new Question
        {
            topic = "DBMS",
            questionText = "Which normalization form removes transitive dependencies?",
            options = new string[] { "1NF", "2NF", "3NF", "BCNF" },
            correctAnswerIndex = 2
        });
        // Additional DBMS questions
        questions.Add(new Question
        {
            topic = "DBMS",
            questionText = "Which SQL clause is used to filter records?",
            options = new string[] { "HAVING", "ORDER BY", "GROUP BY", "WHERE" },
            correctAnswerIndex = 3
        });
        questions.Add(new Question
        {
            topic = "DBMS",
            questionText = "What is the main purpose of the 'JOIN' operation in SQL?",
            options = new string[] { "To combine rows from two or more tables based on a related column", "To remove duplicate records", "To aggregate data", "To sort data in ascending or descending order" },
            correctAnswerIndex = 0
        });
        questions.Add(new Question
        {
            topic = "DBMS",
            questionText = "What does ACID stand for in the context of databases?",
            options = new string[] { "Atomicity, Consistency, Isolation, Durability", "Atomicity, Consistency, Integrity, Durability", "Atomicity, Consistency, Isolation, Dependability", "Atomicity, Consistency, Integration, Durability" },
            correctAnswerIndex = 0
        });
        questions.Add(new Question
        {
            topic = "DBMS",
            questionText = "What is a foreign key in a database?",
            options = new string[] { "A key that uniquely identifies a record", "A key that refers to the primary key of another table", "A key used for encryption", "A key used for indexing" },
            correctAnswerIndex = 1
        });

        // OpenGL questions
        questions.Add(new Question
        {
            topic = "OpenGL",
            questionText = "Which function is used to set the clear color in OpenGL?",
            options = new string[] { "glClear", "glColor", "glClearColor", "glSetClearColor" },
            correctAnswerIndex = 2
        });
        questions.Add(new Question
        {
            topic = "OpenGL",
            questionText = "What is the purpose of the glBindBuffer function in OpenGL?",
            options = new string[] { "To bind a texture", "To bind a vertex buffer", "To bind a shader program", "To bind a frame buffer" },
            correctAnswerIndex = 1
        });
        questions.Add(new Question
        {
            topic = "OpenGL",
            questionText = "Which OpenGL function is used to draw a triangle?",
            options = new string[] { "glDrawArrays", "glDrawElements", "glDrawArraysInstanced", "glDrawElementsInstanced" },
            correctAnswerIndex = 0
        });
        questions.Add(new Question
        {
            topic = "OpenGL",
            questionText = "What is the role of shaders in OpenGL?",
            options = new string[] { "To store textures", "To compute lighting", "To manage buffers", "To handle user input" },
            correctAnswerIndex = 1
        });
        // Additional OpenGL questions
        questions.Add(new Question
        {
            topic = "OpenGL",
            questionText = "What is the purpose of the glViewport function in OpenGL?",
            options = new string[] { "To set the dimensions of the rendering window", "To set the clear color", "To bind a buffer", "To enable a texture unit" },
            correctAnswerIndex = 0
        });
        questions.Add(new Question
        {
            topic = "OpenGL",
            questionText = "Which OpenGL function is used to compile a shader?",
            options = new string[] { "glCompileShader", "glCreateShader", "glLinkProgram", "glUseProgram" },
            correctAnswerIndex = 1
        });
        questions.Add(new Question
        {
            topic = "OpenGL",
            questionText = "What is the function of glEnableVertexAttribArray in OpenGL?",
            options = new string[] { "To enable a vertex attribute array", "To bind a vertex buffer", "To set the color of a vertex", "To clear the vertex buffer" },
            correctAnswerIndex = 1
        });
        questions.Add(new Question
        {
            topic = "OpenGL",
            questionText = "Which OpenGL function is used to create a shader program?",
            options = new string[] { "glCreateProgram", "glCreateShaderProgram", "glCompileProgram", "glLinkShader" },
            correctAnswerIndex = 3
        });
    }



    public List<Question> GetQuestionsByTopic(string topic)
    {
        return questions.FindAll(q => q.topic == topic);
    }
}
