namespace Tests

open NUnit.Framework

[<TestFixture>]
type DatabaseTest () = 
    [<Test>]
    member this.CreateDatabaseTest() = 
        Assert.AreEqual(true, true)

    [<Test>]
    member this.AddToDoTest() = 
        Assert.AreEqual(true, true)

    [<Test>]
    member this.CreateTableTest() = 
        Assert.AreEqual(true, true)
