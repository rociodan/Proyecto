CREATE DATABASE AccentureAcademyBookStore;
GO

USE  AccentureAcademyBookStore;
GO

CREATE TABLE Book
(
	Id int primary key identity(1,1),
	Title varchar(100) unique not null
)
GO

Create Table Author
(
	Id int primary key identity(1,1),
	AuthorName varchar(100) unique not null
)
GO

Create Table WritenBy
(	
	Author_Id int,
	Book_Id int,
	CONSTRAINT FK_AUTOR FOREIGN KEY (Author_Id) 
		REFERENCES Author(Id)
		ON DELETE CASCADE,
	CONSTRAINT FK_BOOK FOREIGN KEY (Book_Id) 
		REFERENCES Book(Id)
		ON DELETE CASCADE,
	CONSTRAINT PK_WRITTEN_BY PRIMARY KEY(Author_Id, Book_Id)
);
GO

CREATE TABLE Gender
(
	Id int primary key identity(1,1),
	TitleGender varchar(100) unique not null 
)
GO

CREATE TABLE Publisher
(
	Id int primary key identity(1,1),
	TitlePublisher varchar(100) unique not null 
)
GO

GO
Create Table PublisherBy
(
	Publisher_Id int,
	Book_Id int,
	CONSTRAINT FK_PUBLISHER FOREIGN KEY (Publisher_Id) 
		REFERENCES Publisher(Id)
		ON DELETE CASCADE,
	CONSTRAINT FK_BOOK_PUBLISHER FOREIGN KEY (Book_Id) 
		REFERENCES Book(Id)
		ON DELETE CASCADE,
	CONSTRAINT PK_PUBLISHER_BY PRIMARY KEY (Publisher_Id, Book_Id)

)
GO

Create Table GenderBy
(
	Gender_Id int,
	Book_Id int,
	CONSTRAINT FK_GENDER FOREIGN KEY (Gender_Id) 
		REFERENCES Gender(Id)
		ON DELETE CASCADE,
	CONSTRAINT FK_BOOK_GENDER FOREIGN KEY (Book_Id) 
		REFERENCES Book(Id)
		ON DELETE CASCADE,
	CONSTRAINT PK_GENDER_BY PRIMARY KEY (Gender_Id, Book_Id)

)
GO

INSERT INTO Gender
(TitleGender)
VALUES
('Drama'),
('Ciencia Ficcion'),
('Biografica'),
('Autoayuda'),
('Cocina'),
('Conspiraciones'),
('Religiosos')


('Cuento'),
('Novela'),
('Leyenda'),
('Fabula'),
('Epopeya'),
('Epistola'),
('Poema Epico'),
('Oda'),
('Elegia'),
('Satira'),
('Cancion'),
('Egloga'),
('Romance'),
('Tragedia'),
('Melodrama'),
('Comedia'),
('Opera'),
('Zarzuela'),
('Farsa'),
('Ensayo'),
('Critica'),
('Cronica'),
('Oratoria'),
('Biografia'),
('Narrativo'),
('Oratoria'),
('Lirica'),
('Tragedia y elegia'),
('Poesia'),
('Epistolar')

GO

INSERT INTO Publisher
(TitlePublisher)
VALUES
('Aguilar'),
('Planeta'),
('Satori'),
('Siglo XXI'),
('Urano')
GO

INSERT INTO Author
(AuthorName)
valueS
('J K Rowling'),
('Lovecraft'),
('J R R Tolkien'),
('George Martin'),
('Dan Brown'),
('Jorge Luis Borges')
GO
