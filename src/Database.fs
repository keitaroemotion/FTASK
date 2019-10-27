module Database

open System
open System.IO
open System.Data.SQLite

let databaseFilename = "/usr/local/etc/ftask/todo.sqlite"
let connectionString = sprintf "Data Source=%s;Version=3;" databaseFilename 

type Task = { 
    Title:   string; 
    DueDate: DateTime; 
    Content: string; 
    State:   string; 
}

let tasks = [
    { 
        Title   = "Go to hospital";
        DueDate = new DateTime(2017, 07, 28, 10, 44, 33);
        Content = "It is very important";
        State   = "DONE"
    }
]

let CreateDatabase() =  
    if not (File.Exists(databaseFilename))
    then
        SQLiteConnection.CreateFile(databaseFilename)

let GetConnection() = 
    let connection = new SQLiteConnection(connectionString)
    connection.Open()
    connection

let CreateTableTask(connection: SQLiteConnection) = 
    let query = new SQLiteCommand( 
                    """
                    create table if not exists Task
                    (
                        Title     varchar(20),
                        DueDate   datetime, 
                        Content   varchar(20),
                        State     varchar(10)
                    )
                    """,
                    connection
                )
    query.ExecuteNonQuery() |> ignore
