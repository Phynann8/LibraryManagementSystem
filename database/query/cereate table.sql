-- Create the Books table
-- This table stores all the information about each book.
CREATE TABLE Books (
    BookID INT PRIMARY KEY IDENTITY(1,1), -- Unique identifier for each book
    ISBN NVARCHAR(20) NOT NULL UNIQUE,   -- Unique ISBN for each book
    Title NVARCHAR(255) NOT NULL,        -- Title of the book
    Author NVARCHAR(255) NOT NULL,       -- Author of the book
    IsAvailable BIT NOT NULL DEFAULT 1   -- 1 for available, 0 for on loan
);
GO

-- Create the Borrowers table
-- This table stores information about people who can borrow books.
CREATE TABLE Borrowers (
    BorrowerID INT PRIMARY KEY IDENTITY(1,1), -- Unique identifier for each borrower
    FirstName NVARCHAR(100) NOT NULL,         -- Borrower's first name
    LastName NVARCHAR(100) NOT NULL,          -- Borrower's last name
    Email NVARCHAR(255) UNIQUE,               -- Borrower's email (optional, but good for contact)
    RegistrationDate DATE NOT NULL DEFAULT GETDATE() -- When the borrower was registered
);
GO

-- Create the Loans table
-- This table acts as a link between Books and Borrowers, tracking who has what.
CREATE TABLE Loans (
    LoanID INT PRIMARY KEY IDENTITY(1,1),       -- Unique identifier for each loan
    BookID INT NOT NULL,                        -- Links to the Books table
    BorrowerID INT NOT NULL,                    -- Links to the Borrowers table
    DateIssued DATE NOT NULL,                   -- The date the book was loaned out
    DateDue DATE NOT NULL,                      -- The date the book is expected back
    DateReturned DATE NULL,                     -- The actual date the book was returned (NULL if still on loan)
    FOREIGN KEY (BookID) REFERENCES Books(BookID),
    FOREIGN KEY (BorrowerID) REFERENCES Borrowers(BorrowerID)
);
GO
