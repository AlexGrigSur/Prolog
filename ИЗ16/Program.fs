open System
open System.IO
open System.Data
open System.Windows.Forms
open MySql.Data.MySqlClient

let ExecuteCommand (commandStr:string) (connectionStr:string) = 
    use connection = new MySqlConnection(connectionStr)
    connection.Open()
    use command = new MySqlCommand(commandStr,connection)
    command.ExecuteNonQuery() |> ignore
    ()

[<EntryPoint>]
let main argv =
    ExecuteCommand ("CREATE DATABASE IF NOT EXISTS `IZ16`") ("server=localhost;port=3306;username=root;password=;")
    ExecuteCommand ("CREATE TABLE IF NOT EXISTS `BulletCalc` (`id` INT(11) NOT NULL primary key AUTO_INCREMENT UNIQUE, `BulletName` VARCHAR(150) NOT NULL, `Weight` FLOAT(11), `Speed` INT(11), `On0` INT(11),`On100` INT(11), `On200` INT(11), `On300` INT(11))") ("server=localhost;port=3306;username=root;password=;database=IZ16")
    do Application.Run(MainWindow.mainForm)
    0 
