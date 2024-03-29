module Database

open System
open System.Data.SQLite
open System.IO

let databaseFilename = "/usr/local/etc/ftask/todo.sqlite"
let connectionString = sprintf "Data Source=%s;Version=3;" databaseFilename 

type Task = { 
    Title:   string; 
    DueDate: DateTime; 
    Content: string; 
    State:   string; 
}

let CreateDatabase() =  
    if not (File.Exists(databaseFilename))
    then
        SQLiteConnection.CreateFile(databaseFilename)

let GetConnection() = 
    let connection = new SQLiteConnection(connectionString)
    connection.Open()
    connection

let AddToDo(
        connection: SQLiteConnection,
        title:      string,
        dueDate:    DateTime,
        content:    string,
        state:      string
    ) = 
    let sql = 
        """
           insert into Task(
                           Title,
                           DueDate,
                           Content,
                           State 
                       )
                       values(
                           @title, 
                           @dueDate, 
                           @content,
                           @state
                       )
        """ 
    use query = new SQLiteCommand(sql, connection)
    query.Parameters.AddWithValue("@title",   title)   |> ignore 
    query.Parameters.AddWithValue("@dueDate", dueDate) |> ignore 
    query.Parameters.AddWithValue("@content", content) |> ignore 
    query.Parameters.AddWithValue("@state",   state)   |> ignore 
    query.ExecuteNonQuery()

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
