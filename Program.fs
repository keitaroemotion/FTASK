﻿open System

[<EntryPoint>]
let main argv =
    //
    // Task
    //   add(+) with details (-> due date can be added)
    //   remove(+)
    //   update
    //   list (tasks)         
    //   add duedate to task 
    //   modify duedate in task 
    let connection = Database.GetConnection()
    Database.CreateTableTask(connection) |> ignore
    Database.AddToDo(
        connection,
        "Title",
        new DateTime(2019, 10, 11),
        "None",
        "DONE"
    ) |> ignore
     
    printfn "Hello World from F#!"
    0 // return an integer exit code
