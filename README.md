# Hotel Booking Web Application

This web application allows users to book hotel rooms, browse available hotels, and manage their bookings. The solution consists of four projects:

1. **API**: Contains the logic of the booking operation.
2. **MVC**: The web application that communicates with the API and displays booking data.
3. **Core Class Library**: Contains models , Enums , Attributes , ReposInterfaces and DTOs. This library is referenced by both the API and MVC projects.
4. **EF Class Library**: Contains Confiuration Classes by Flent API , Migrations , Repos and ApplicationDBContext. This library is referenced by the API .

## Getting Started

### Prerequisites

- Visual Studio 2022 or later
- SQL Server
- .NET 6.0 SDK or later

### Installation

1. **Clone the repository**:
    ```sh
    git clone [repository link]
    ```

2. **Open the solution** in Visual Studio.

3. **Set the startup project**:
    - Right-click on the solution in Solution Explorer.
    - Select **Set Startup Projects...**.
    - Choose **Multiple startup projects**.
    - Set both **API** and **MVC** projects to **Start**.

4. **Add migrations and update the database**:
    - Open the **Package Manager Console** in Visual Studio.
    - Set the **API** project as the default project.
    - Run the following commands:
        ```sh
        Add-Migration InitialCreate
        Update-Database
        ```

### Running the Application

1. **Run the solution**:
    - Press **F5** or click on **Start** to run both the API and MVC projects.

2. **Register and Login**:
    - To book a room or browse hotels, you must be registered and logged in.
    - The application will direct you to the registration page if you attempt to access protected routes.

3. **Booking a Room**:
    - After logging in, you can book a room by providing the required information:
        - Customer name
        - National ID
        - Phone number
        - Hotel branch
        - Check-in and check-out dates
        - Number of rooms
        - Room type (single, double, suite)
        - Number of adults and children for each room

### Features

- **User Authentication**: Register, login, and logout functionality. Tokens are managed in the session.
- **Booking Management**: Create booking, view booking list, and booking details.
- **Validation**: Ensures rooms are available at the selected branch and of the desired type. The number of rooms must be between 1 and 10. 
- **Discounts**: 5% discount for customers who have previously booked.

### Validations

- **Room Availability**: Checks if the requested rooms are available at the selected branch and of the desired type.
- **Number of Rooms**: Must be greater than zero and less than ten. Errors will be added to the model state to inform the user.
- **Checkin Date**: Must be Later than the Date of Now.
- **Checkout Date**: Must be Later than the Checkin.



## Database Design

The database design includes the following tables:

- **Customers**: Stores customer details.
- **Bookings**: Stores booking information.
- **Rooms**: Stores room details.
- **Branches**: Stores hotel branch information.
- **Hotels**: Stores hotel information.
- **Employess**: Stores Employees information.
- **Beds**: Stores Beds information.
- **Customer Booking**: Join table to reation Mant to Many between Customer and Bookings.
  

For more details about the ERD you can see it after in Database Diagrams after Updating Database Successfully.

## Technologies Used

- **Backend**: ASP.NET Core MVC, C#
- **Frontend**: HTML , Razor Pages
- **Database**: MS SQL Server

## Contact

For any questions or feedback, please contact [Omar Ahmed Abo Ziada](mailto:o.ahmed9847@gmail.com).
Phone: +20 115 935 1955
