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


## Adding a Setup Project with Visual Studio Installer

Follow these steps to create a setup project for your application and include your database files in the installer.

### Step-by-Step Instructions

1. **Add a New Project to the Solution**  
   - Right-click on the **Solution** in the **Solution Explorer**.
   - Select **Add** > **New Project** from the context menu.
   
2. **Choose the Installer Project Type**  
   - In the **New Project** dialog, expand **Other Project Types**.
   - Navigate to **Setup and Deployment** > **Visual Studio Installer**.
   - Select **Setup Project** and name it (e.g., `MyAppInstaller`).
   - Click **OK** to add the project.

3. **Install the Visual Studio Installer Extension (if not already installed)**  
   If you do not see the **Visual Studio Installer** option in the **New Project** dialog, you may need to install the extension. Follow these steps:
   - Go to **Extensions** > **Manage Extensions** in Visual Studio.
   - Search for **Visual Studio Installer Projects** and install it.
   - Restart Visual Studio after the installation to enable the new project types.

4. **Configure the Application Folder**  
   - In the newly added **Setup Project**, open the **File System** editor from **View** > **Editor** > **File System**.
   - In the **File System** editor, expand the **Application Folder**.

5. **Add Project Output**  
   - Right-click on the **Application Folder** and select **Add** > **Project Output**.
   - In the dialog that appears, choose **Primary Output** from your Windows Forms application project.
   - This adds the compiled output of your main application to the installer.

6. **Include Database Files**  
   - Right-click on the **Application Folder** again and select **Add** > **File**.
   - Browse and select your database files (`DB.mdf` and `DB_log.ldf`) to include them in the installer.
   - These files will be copied to the target machine along with your application.

7. **Create a Shortcut**  
   - Right-click on the **User's Desktop** in the **File System** editor and select **Create New Shortcut**.
   - In the **Create Shortcut** dialog, select the **Primary Output** (the main application executable) from the **Application Folder**.
   - This will create a shortcut on the user's desktop that points to your application.

8. **Build the Installer**  
   - Right-click on the **Setup Project** in **Solution Explorer** and choose **Build**.
   - The installer package will be created and saved in the output directory (typically under the **Debug** or **Release** folder).

9. **Distribute the Installer**  
   - Once the build completes, you can find the `.msi` installer file in the **bin** folder of the **Setup Project**.
   - This installer can now be distributed, and it will install your application along with the database and the desktop shortcut.

By following these steps, you can create an installer for your Windows Forms application that includes the necessary database files and a shortcut to the user’s desktop.

