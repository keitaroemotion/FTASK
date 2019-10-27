module Database

open System
open System.Data.SQLite

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

let databaseFilename = "todo.sqlite"
let connectionString = sprintf "Data Source=%s;Version=3;" databaseFilename  
SQLiteConnection.CreateFile(databaseFilename)

let connection = new SQLiteConnection(connectionString)
connection.Open()

let structureSql =
    """
    create table Task
    (
        Title     varchar(20),
        DueDate   datetime, 
        Content   varchar(20),
        State     varchar(10),
    )
    """

let structureCommand = new SQLiteCommand(structureSql, connection)
structureCommand.ExecuteNonQuery() |> ignore
