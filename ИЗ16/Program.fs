open System
open System.IO
open System.Windows.Forms
open MySql.Data.MySqlClient

[<EntryPoint>]
let main argv =
    do Application.Run(MainWindow.firstWindow.mainForm)
    0 
