# BookHaven C# Windows Forms Application

This project is a Windows Forms application built with C#. The following steps outline how to add a service-based database to the application.

## Adding a Service-based Database

Follow these steps to add a service-based database to your C# Windows Forms application:

1. **Open Your Project**  
   Launch Visual Studio and open your existing Windows Forms application project.

2. **Add a New Item**  
   - Right-click on your project in the **Solution Explorer**.
   - Select **Add** > **New Item** from the context menu.

3. **Choose Service-based Database**  
   - In the **Add New Item** window, scroll down and select **Service-based Database**.
   - This will create a new `.mdf` (Microsoft Data File) that can be used to store your application's data.

4. **Name the Database**  
   - Enter a name for the database file and click **Add**.
   - The database file will be added to your project under the **App_Data** folder.

5. **Configure the Database**  
   - After adding the database, Visual Studio will open the **Server Explorer** window, where you can manage the database schema and tables.
   - Right-click on the database in the **Server Explorer** to create tables, views, stored procedures, and more.

6. **Connect the Database to Your Application**  
   - You can now create a connection string in your `App.config` file to connect your application to the database.
   - Example connection string:
     ```xml
     <connectionStrings>
         <add name="YourDatabaseConnectionString" 
              connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\YourDatabaseName.mdf;Integrated Security=True;Connect Timeout=30" 
              providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```

7. **Use the Database in Your Application**  
   - You can now use `SqlConnection`, `SqlCommand`, and other ADO.NET classes to interact with the database from your Windows Forms application.

By following these steps, you'll be able to integrate a service-based database into your C# Windows Forms application.
